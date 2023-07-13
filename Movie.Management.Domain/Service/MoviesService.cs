using AutoMapper;
using Movie.Management.Domain.ModelDto;
using Movie.Management.Domain.Service.Interface;
using Movie.Management.Infra.Models;
using Movie.Management.Infra.Repository.Interface;

namespace Movie.Management.Domain.Service
{
    public class MoviesService : IMoviesService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MoviesService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public Task<ResponseDto> GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetMovieById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> AddMovieAsync(MovieDto movieDto)
        {
            if (VerifyYear(movieDto.Year))
            {
                var movie = _mapper.Map<Movies>(movieDto);

                _movieRepository.Add(movie);
                await _movieRepository.SaveChanges();

                return new ResponseDto();
            }
            
            return new ResponseDto();
        }

        private static bool VerifyYear(int year)
        {
            return year >= 1000 && year <= 9999;
        }

    }
}
