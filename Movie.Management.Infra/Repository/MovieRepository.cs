using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Movie.Management.Infra.Data;
using Movie.Management.Infra.Models;
using Movie.Management.Infra.Repository.Interface;
using Constants = Movie.Management.Infra.Util.Constants;
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
            var movies = await _distributedCache.GetAsync(Constants.CACHE_KEY);

            if (movies != null)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Movies>>(Encoding.UTF8.GetString(movies));
            }

            var response = await _dbContext.Movies.AsNoTracking()
                                                  //.Where(x => x.Title.Contains(""))
                                                  .Skip(skip)
                                                  .Take(take)
                                                  .ToListAsync();

            await SetCacheRedis(response);

            return response;
        }

        public async Task<Movies> GetByIdAsync(int id)
        {
            return await _context.Movies.SingleOrDefaultAsync(d => d.Id == id);
        }

        private async Task SetCacheRedis(IEnumerable<Movies> movies)
        {
            var serialize = JsonConvert.SerializeObject(movies);
            var redisValue = Encoding.UTF8.GetBytes(serialize);

            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(1));

            await _distributedCache.SetAsync(Constants.CACHE_KEY, redisValue, options);
        }
    }
}
