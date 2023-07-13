using Movie.Management.Infra.Data;
using Movie.Management.Infra.Repository.Interface;

namespace Movie.Management.Infra.Repository
{
    public class EntityBaseRepository : IEntityBaseRepository
    {
        protected readonly AppDbContext _dbContext;

        public EntityBaseRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async void Add<T>(T entity) where T : class
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
