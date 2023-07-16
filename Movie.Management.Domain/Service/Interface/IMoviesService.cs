using Movie.Management.Domain.Helpers;
using Movie.Management.Domain.ModelDto;

namespace Movie.Management.Domain.Service.Interface
{
    public interface IMoviesService
    {
        Task<ResultOperation<MoviePaginatedDto>> GetMoviesPaginated(int pageNumber, int recordsPerPage);
        Task<ResultOperation<MovieDto>> GetMovieById(int id);
        Task<ResultOperation<MovieDto>> AddMovieAsync(MovieDto movieDto);
    }
}
