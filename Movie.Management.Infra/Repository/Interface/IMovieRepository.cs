using Movie.Management.Infra.Models;

namespace Movie.Management.Infra.Repository.Interface
{
    public interface IMovieRepository : IEntityBaseRepository
    {
        Task<IEnumerable<Movies>> GetAllAsync(int skip, int take);

        Task<Movies> GetByIdAsync(int id);

        IQueryable<Movies> GetPageByNumberAndRecords(int pageNumber, int recordsPerPage);

        Task<int> GetTotalRecords();
    }
}
