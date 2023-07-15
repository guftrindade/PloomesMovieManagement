using Movie.Management.Domain.Helpers;
using Movie.Management.Domain.ModelDto;

namespace Movie.Management.Domain.Service.Interface
{
    public interface IMoviesService
    {
        Task<ResultOperation<IEnumerable<MovieDto>>> GetAllMoviesAsync(int skip, int take);
        Task<ResultOperation<MovieDto>> GetMovieById(int id);
        Task<ResultOperation<MovieDto>> AddMovieAsync(MovieDto movieDto);
    }
}
