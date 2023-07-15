using Movie.Management.Domain.Helpers;
using Movie.Management.Domain.ModelDto;

namespace Movie.Management.Domain.Service.Interface
{
    public interface IMoviesService
    {
        Task<ResultOperation<IEnumerable<MovieDto>>> GetAllMoviesAsync();
        Task<ResultOperation<MovieDto>> GetMovieById(int id);
        Task<ResultOperation<MovieDto>> AddMovieAsync(MovieDto movieDto);
    }
}
