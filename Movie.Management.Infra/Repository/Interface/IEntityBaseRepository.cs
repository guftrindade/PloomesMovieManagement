namespace Movie.Management.Infra.Repository.Interface
{
    public interface IEntityBaseRepository
    {
        public void Add<T>(T entity) where T : class;
        Task<int> SaveChanges();
    }
}
