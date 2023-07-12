using Movie.Management.Api.ModelsDto;
using Movie.Management.Api.Service.Interface;

namespace Movie.Management.Api.Service
{
    public class MovieService : IMovieService
    {
        public Task<ResponseDto> GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> AddMovieAsync(MovieDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
