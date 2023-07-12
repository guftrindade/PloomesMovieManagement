using Movie.Management.Api.ModelsDto;

namespace Movie.Management.Api.Service.Interface
{
    public interface IMovieService
    {
        Task<ResponseDto> GetAllMoviesAsync();
        Task<ResponseDto> AddMovieAsync(MovieDto requestDto);
    }
}
