using Movie.Management.Infra.Models;

namespace Movie.Management.Infra.Repository.Interface
{
    public interface IMovieRepository : IEntityBaseRepository
    {
        IEnumerable<Movies> GetAllMovies();

        Movies GetMovieById(int id);
    }
}
