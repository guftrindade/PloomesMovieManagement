using AutoMapper;
using Movie.Management.Domain.ModelDto;
using Movie.Management.Domain.Service.Interface;
using Movie.Management.Domain.Validations;
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

        public async Task<IEnumerable<Movies>> GetAllMoviesAsync()
        {
            var response = await _movieRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Movies>>(response);
        }

        public async Task<Movies> GetMovieById(int id)
        {
            var response = await _movieRepository.GetByIdAsync(id);
            return _mapper.Map<Movies>(response);
        }

        public async Task<Movies> AddMovieAsync(MovieDto movieDto)
        {
            if (MoviesValidation.IsValidYear(movieDto.Year))
            {
                var movie = _mapper.Map<Movies>(movieDto);

                _movieRepository.Add(movie);
                await _movieRepository.SaveChanges();

                return movie;
            }

            //implementar notificação de erro
            return null;
        }
    }
}
