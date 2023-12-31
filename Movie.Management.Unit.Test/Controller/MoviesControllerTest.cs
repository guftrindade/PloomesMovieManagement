﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Movie.Management.Api.Controllers;
using Movie.Management.Domain.ModelDto;
using Movie.Management.Domain.Service.Interface;
using Movie.Management.Unit.Test.Configuration;
using Movie.Management.Unit.Test.Mocks;

namespace Movie.Management.Unit.Test.Controller
{
    public class MoviesControllerTest : ConfigBase
    {
        private readonly Mock<IMoviesService> _movieServiceMock;
        private readonly Mock<ILogger<MoviesController>> _logger;

        public MoviesControllerTest()
        {
            _movieServiceMock = new Mock<IMoviesService>();
            _logger = new Mock<ILogger<MoviesController>>();
        }

        private MoviesController GetController()
        {
            return new MoviesController(_movieServiceMock.Object, _mapper, _logger.Object);
        }

        [Fact(DisplayName = "Get all movies")]
        public async Task GetAsync_ShouldReturnAllMovies()
        {
            var movieDtoMock = MovieMock.ResultOperationGetMoviePaginatedFaker.Generate();

            _movieServiceMock.Setup(x => x.GetMoviesPaginated(1,10))
                .ReturnsAsync(movieDtoMock);

            var response = await GetController().GetAsync();

            var result = Assert.IsType<OkObjectResult>(response.Result);
            Assert.NotNull(result.Value);
        }

        [Fact(DisplayName = "Get movie by Id")]
        public async Task GetAsync_ShouldReturnMovieById()
        {
            var responseMovieMock = MovieMock.ResultOperationFaker.Generate();
            var movieId = 1;

            _movieServiceMock.Setup(x => x.GetMovieById(movieId))
                .ReturnsAsync(responseMovieMock);

            var response = await GetController().GetByIdAsync(movieId);

            var result = Assert.IsType<OkObjectResult>(response.Result);
            Assert.NotNull(result.Value);
        }

        [Fact(DisplayName = "Get movie by non-existent MovieId")]
        public async Task GetAsync_WhenMovieNonExistent_ShouldReturnNotFound()
        {
            var responseMovieMock = MovieMock.ResultOperationFaker.Generate();
            responseMovieMock.Result = null;
            var movieId = 1;

            _movieServiceMock.Setup(x => x.GetMovieById(movieId))
                .ReturnsAsync(responseMovieMock);

            var response = await GetController().GetByIdAsync(movieId);

            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact(DisplayName = "Create new movie")]
        public async Task PostAsync_ShouldReturnStatusCode201()
        {
            var movieRequestVMMock = MovieMock.MovieRequestVMFaker.Generate();
            var responseMock = MovieMock.ResultOperationFaker.Generate();

            _movieServiceMock.Setup(x => x.AddMovieAsync(It.IsAny<MovieDto>()))
                .ReturnsAsync(responseMock);

            var response = await GetController().PostAsync(movieRequestVMMock);

            var result = Assert.IsType<CreatedResult>(response);
            Assert.NotNull(result.Value);
        }

        [Fact(DisplayName = "Create new movie with invalid data")]
        public async Task PostAsync_WhenSuccessIsFalse_ShouldReturnBadRequest()
        {
            var movieRequestVMMock = MovieMock.MovieRequestVMFaker.Generate();
            var responseMock = MovieMock.ResultOperationFaker.Generate();
            responseMock.Errors.Messages.Add("Service processing error.");

            _movieServiceMock.Setup(x => x.AddMovieAsync(It.IsAny<MovieDto>()))
                .ReturnsAsync(responseMock);

            var response = await GetController().PostAsync(movieRequestVMMock);

            var result = Assert.IsType<BadRequestObjectResult>(response);
            Assert.NotNull(result.Value);
        }
    }
}
