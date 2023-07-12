using Movie.Management.Infra.Data;
using Movie.Management.Infra.Repository.Interface;

namespace Movie.Management.Infra.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
