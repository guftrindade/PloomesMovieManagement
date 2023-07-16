using Movie.Management.Infra.Models;

namespace Movie.Management.Infra.Repository.Interface
{
    public interface IMovieRepository : IEntityBaseRepository
    {
        IQueryable<Movies> GetPageByNumberAndRecords(int pageNumber, int recordsPerPage);
        Task<Movies> GetByIdAsync(int id);
        Task<int> GetTotalRecords();
    }
}
