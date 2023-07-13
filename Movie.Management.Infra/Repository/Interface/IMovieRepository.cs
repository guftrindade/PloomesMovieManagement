using Movie.Management.Infra.Models;

namespace Movie.Management.Infra.Repository.Interface
{
    public interface IMovieRepository : IEntityBaseRepository
    {
        Task<IEnumerable<Movies>> GetAllAsync();

        Task<Movies> GetByIdAsync(Guid id);
    }
}
