using Movie.Management.Domain.ModelDto;
using Movie.Management.Infra.Models;

namespace Movie.Management.Domain.Service.Interface
{
    public interface IMoviesService
    {
        Task<IEnumerable<Movies>> GetAllMoviesAsync();
        Task<Movies> GetMovieById(int id);
        Task<Movies> AddMovieAsync(MovieDto movieDto);
    }
}
