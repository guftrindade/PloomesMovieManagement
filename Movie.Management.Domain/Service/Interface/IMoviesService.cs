using Movie.Management.Domain.ModelDto;

namespace Movie.Management.Domain.Service.Interface
{
    public interface IMoviesService
    {
        Task<ResponseDto> GetAllMoviesAsync();
        Task<ResponseDto> GetMovieById(Guid id);
        Task<ResponseDto> AddMovieAsync(MovieDto movieDto);
    }
}
