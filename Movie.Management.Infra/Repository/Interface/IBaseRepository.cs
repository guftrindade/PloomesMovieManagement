namespace Movie.Management.Infra.Repository.Interface
{
    public interface IBaseRepository
    {
        public void Add<T>(T entity) where T : class;
        bool SaveChanges();
    }
}
