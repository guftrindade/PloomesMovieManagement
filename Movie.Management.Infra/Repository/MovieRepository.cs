using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Movie.Management.Infra.Data;
using Movie.Management.Infra.Models;
using Movie.Management.Infra.Repository.Interface;
using System.Text;
using Newtonsoft.Json;

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

        public async Task<IEnumerable<Movies>> GetAllAsync(int skip, int take)
        {
            var response = await _dbContext.Movies.AsNoTracking()
                                                  //.Where(x => x.Title.Contains(""))
                                                  .Skip(skip)
                                                  .Take(take)
                                                  .ToListAsync();

            return response;
        }

        public IQueryable<Movies> GetPageByNumberAndRecords(int pageNumber, int recordsPerPage)
        {
            var response = _dbContext.Movies.Skip((pageNumber - 1) * recordsPerPage)
                                            .Take(recordsPerPage)
                                            .AsQueryable();     

            
            return response;
        }

        public async Task<int> GetTotalRecords()
        {
            var response = await _dbContext.Movies.CountAsync();

            return response;
        }

        public async Task<Movies> GetByIdAsync(int id)
        {
            var movies = await _distributedCache.GetAsync(GetKeyRedisMovieId(id));

            if (movies != null)
            {
                return JsonConvert.DeserializeObject<Movies>(Encoding.UTF8.GetString(movies));
            }

            var response = await _context.Movies.SingleOrDefaultAsync(d => d.Id == id);

            if (response is not null)
            {
                await SetCacheRedis(response);
            }

            return response;
        }

        private async Task SetCacheRedis(Movies movies)
        {
            var serialize = JsonConvert.SerializeObject(movies);
            var redisValue = Encoding.UTF8.GetBytes(serialize);

            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(1));

            await _distributedCache.SetAsync(GetKeyRedisMovieId(movies.Id), redisValue, options);
        }

        private static string GetKeyRedisMovieId(int movieId)
        {
            return $"movieId_{movieId}";
        }
    }
}
