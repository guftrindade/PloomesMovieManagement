using AutoMapper;
using Movie.Management.Domain.Helpers;
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

        public async Task<ResultOperation<IEnumerable<MovieDto>>> GetAllMoviesAsync(int skip, int take)
        {
            var response = await _movieRepository.GetAllAsync(skip, take);

            return new ResultOperation<IEnumerable<MovieDto>>
            {
                Result = _mapper.Map<IEnumerable<MovieDto>>(response)
            };
        }

        public async Task<ResultOperation<MovieDto>> GetMovieById(int id)
        {
            var response = await _movieRepository.GetByIdAsync(id);

            return new ResultOperation<MovieDto>
            {
                Result = _mapper.Map<MovieDto>(response)
            };
        }

        public async Task<ResultOperation<MovieDto>> AddMovieAsync(MovieDto movieDto)
        {
            var returnOperation = AddMoviesValidation(movieDto);

            if (returnOperation.Success)
            {
                var movie = _mapper.Map<Movies>(movieDto);

                _movieRepository.Add(movie);
                await _movieRepository.SaveChanges();

                returnOperation.Result = _mapper.Map<MovieDto>(movie);
            }

            return returnOperation;
        }

        public static ResultOperation<MovieDto> AddMoviesValidation(MovieDto movieDto)
        {
            var returnOperation = new ResultOperation<MovieDto>();

            if (!MoviesValidation.IsValidYear(movieDto.Year))
            {
                returnOperation.Errors.Messages.Add("[Year] fiel must be 'YYYY' format!");
            }

            return returnOperation;
        }
    }
}
