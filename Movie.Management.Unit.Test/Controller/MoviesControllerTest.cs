using Microsoft.AspNetCore.Mvc;
using Moq;
using Movie.Management.Api.Controllers;
using Movie.Management.Domain.Service.Interface;
using Movie.Management.Unit.Test.Configuration;
using Movie.Management.Unit.Test.Mocks;

namespace Movie.Management.Unit.Test.Controller
{
    public class MoviesControllerTest : ConfigBase
    {
        private readonly Mock<IMoviesService> _movieServiceMock;

        public MoviesControllerTest()
        {
            _movieServiceMock = new Mock<IMoviesService>();
        }

        private MoviesController GetController()
        {
            return new MoviesController(_movieServiceMock.Object, _mapper);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnAllMovies()
        {
            var movieDtoMock = MovieMock.MovieDtoFaker.Generate(2);

            _movieServiceMock.Setup(x => x.GetAllMoviesAsync())
                .ReturnsAsync(movieDtoMock);

            var response = await GetController().GetAsync();

            var result = Assert.IsType<OkObjectResult>(response.Result);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnMovieById()
        {
            var movieDtoMock = MovieMock.MovieDtoFaker.Generate();

            _movieServiceMock.Setup(x => x.GetMovieById(1))
                .ReturnsAsync(movieDtoMock);

            var response = await GetController().GetAsync();

            var result = Assert.IsType<OkObjectResult>(response.Result);
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async Task PostAsync_ShouldReturnStatusCode201()
        {
            var movieRequestVMMock = MovieMock.MovieRequestVMFaker.Generate();
            var movieDtoMock = MovieMock.MovieDtoFaker.Generate();
            var responseMock = MovieMock.ResultOperationFaker.Generate();

            //Aqui o método retorna o valor mas na controller está vindo null
            _movieServiceMock.Setup(x => x.AddMovieAsync(movieDtoMock))
                .ReturnsAsync(responseMock);

            var response = await GetController().PostAsync(movieRequestVMMock);

            var actionResult = Assert.IsType<CreatedResult>(response);
        }
    }
}
