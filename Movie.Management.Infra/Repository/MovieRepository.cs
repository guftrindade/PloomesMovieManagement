using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Movie.Management.Infra.Data;
using Movie.Management.Infra.Models;
using Movie.Management.Infra.Repository.Interface;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Movie.Management.Infra.Repository
{
    public class MovieRepository : EntityBaseRepository, IMovieRepository
    {
        private readonly AppDbContext _context;
        private readonly IDistributedCache _distributedCache;

        public MovieRepository(AppDbContext context, IDistributedCache distributedCache) : base(context)
        {
            _context = context;
            _distributedCache = distributedCache;
        }

        public IQueryable<Movies> GetPageByNumberAndRecords(int pageNumber, int recordsPerPage)
        {
            return _dbContext.Movies.Skip((pageNumber - 1) * recordsPerPage)
                                    .Take(recordsPerPage)
                                    .AsQueryable();     
        }

        public async Task<int> GetTotalRecords()
        {
            return await _dbContext.Movies.CountAsync();
        }

        public async Task<Movies> GetByIdAsync(int id)
        {
            try
            {
                var cacheKey = GetKeyRedisMovieId(1);
                var movies = await _distributedCache.GetAsync(cacheKey);

                if (movies != null)
                {
                    return JsonConvert.DeserializeObject<Movies>(Encoding.UTF8.GetString(movies));
                }

                var response = await _context.Movies.SingleOrDefaultAsync(d => d.Id == id);

                if (response is not null)
                {
                    await SetCacheRedis(response, cacheKey);
                }

                return response;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return await _context.Movies.SingleOrDefaultAsync(d => d.Id == id);
            }
        }

        private async Task SetCacheRedis(Movies movies, string cacheKey)
        {
            var serialize = JsonConvert.SerializeObject(movies);
            var redisValue = Encoding.UTF8.GetBytes(serialize);

            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(2));

            await _distributedCache.SetAsync(cacheKey, redisValue, options);
        }

        private static string GetKeyRedisMovieId(int movieId)
        {
            return $"movieId_{movieId}";
        }
    }
}
