using Movie.Management.Infra.Models;

namespace Movie.Management.Infra.Repository.Interface
{
    public interface IMovieRepository : IBaseRepository
    {
        IEnumerable<MovieModel> Get();
    }
}
