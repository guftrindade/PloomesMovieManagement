using Movie.Management.Domain.Helpers;
using Movie.Management.Domain.ModelDto;

namespace Movie.Management.Domain.Service.Interface
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto> GetMovieById(int id);
        Task<ResultOperation<MovieDto>> AddMovieAsync(MovieDto movieDto);
    }
}
