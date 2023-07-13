using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie.Management.Api.ModelsDto;
using Movie.Management.Api.ViewModel;
using Movie.Management.Domain.ModelDto;
using Movie.Management.Domain.Service.Interface;
using NSwag.Annotations;

namespace Movie.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("Movies Management", Description = "Movies Management Services")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMoviesService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <response code="200">Return the list of movies.</response>
        /// <response code="401">The server can not find the requested resource.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieResponseViewModel>> GetAsync()
        {
            var response = await _movieService.GetAllMoviesAsync();
            var responseVm = _mapper.Map<IEnumerable<MovieResponseViewModel>>(response);

            if (responseVm == null)
            {
                return NotFound();
            }

            return Ok(responseVm);
        }

        /// <summary>
        /// Get movie by Id
        /// </summary>
        /// <response code="200">Return a movie by Id</response>
        /// <response code="401">The server can not find the requested resource.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieResponseViewModel>> GetByIdAsync(int id)
        {
            var response = await _movieService.GetMovieById(id);
            var responseVm = _mapper.Map<MovieResponseViewModel>(response);

            if (responseVm == null)
            {
                return NotFound();
            }

            return Ok(responseVm);
        }

        /// <summary>
        /// Create movie
        /// </summary>
        /// <response code="201">Movie successfully registered.</response>
        /// <response code="400">The request could not be understood by the server due to incorrect syntax.</response>
        /// <response code="500">Erro interno da API.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostAsync([FromBody] MovieRequestViewModel requestVm)
        {
            var requestDto = _mapper.Map<MovieDto>(requestVm);

            var response = await _movieService.AddMovieAsync(requestDto);

            var responseVm = _mapper.Map<MovieResponseViewModel>(response);

            if (responseVm == null)
            {
                return BadRequest();
            }

            return Created(nameof(GetByIdAsync), response);
        }
    }
}
