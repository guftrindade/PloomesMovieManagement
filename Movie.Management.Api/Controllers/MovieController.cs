using Microsoft.AspNetCore.Mvc;
using Movie.Management.Api.ModelsDto;
using Movie.Management.Api.Service.Interface;
using NSwag.Annotations;

namespace Movie.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("Movie Management", Description = "Movie Management Services")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <response code="200">Retorna lista de endereços.</response>
        /// <response code="401">The server can not find the requested resource.</response>
        [HttpGet("movies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseDto>> GetAsync()
        {
            var response = await _movieService.GetAllMoviesAsync();

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Create movie
        /// </summary>
        /// <response code="201">Movie successfully registered.</response>
        /// <response code="400">The request could not be understood by the server due to incorrect syntax.</response>
        /// <response code="500">Erro interno da API.</response>
        [HttpPost("movie")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseDto>> PostAsync([FromBody] MovieDto movieDto)
        {
            var response = await _movieService.AddMovieAsync(movieDto);

            if (response == null)
            {
                return BadRequest();
            }

            return Created(nameof(GetAsync), response);
        }
    }
}
