﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie.Management.Api.ViewModel;
using Movie.Management.Api.ViewModel.CustomResponse;
using Movie.Management.Domain.Helpers;
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
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(IMoviesService movieService, IMapper mapper, ILogger<MoviesController> logger)
        {
            _movieService = movieService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all movies / Listar todos os filmes cadastrados.
        /// </summary>
        /// <response code="200">Return the list of movies.</response>
        /// <response code="401">The server can not find the requested resource.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieResponseViewModel>> GetAsync()
        {
            try
            {
                var resultOperation = await _movieService.GetAllMoviesAsync();

                if (resultOperation.Result is null)
                {
                    return NotFound();
                }

                var responseVM = _mapper.Map<IEnumerable<MovieResponseViewModel>>(resultOperation.Result);
                return Ok(responseVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ERRO");
                return StatusCode(StatusCodes.Status500InternalServerError, new ConfigurationResponse().SetErrorResponse(ex));
            }
        }

        /// <summary>
        /// Get movie by Id / Buscar filme por Id
        /// </summary>
        /// <response code="200">Return a movie by Id</response>
        /// <response code="401">The server can not find the requested resource.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieResponseViewModel>> GetByIdAsync(int id)
        {
            try
            {
                var resultOperation = await _movieService.GetMovieById(id);

                if (resultOperation.Result is null)
                {
                    return NotFound();
                }

                var responseVM = _mapper.Map<MovieResponseViewModel>(resultOperation.Result);
                return Ok(responseVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ERRO");
                return StatusCode(StatusCodes.Status500InternalServerError, new ConfigurationResponse().SetErrorResponse(ex));
            }
        }

        /// <summary>
        /// Create movie / Cadastrar filme
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
            var resultOperation = new ResultOperation<MovieResponseViewModel>();

            try
            {
                var resultOperationService = await _movieService.AddMovieAsync(requestDto);

                if (!resultOperationService.Success)
                {
                    return BadRequest(resultOperationService.Errors);
                }

                resultOperation.Result = _mapper.Map<MovieResponseViewModel>(resultOperationService.Result);
                return Created(nameof(GetByIdAsync), resultOperation.Result);
            }
            catch (Exception ex)
            {
                resultOperation.Errors.Messages.Add(ex.Message);
                _logger.LogError(ex.Message, "ERRO");
                return StatusCode(StatusCodes.Status500InternalServerError, new ConfigurationResponse().SetErrorResponse(ex));
            }
        }
    }
}
