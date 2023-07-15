using Moq;
using Movie.Management.Domain.ModelDto;
using Movie.Management.Domain.Service;
using Movie.Management.Infra.Models;
using Movie.Management.Infra.Repository.Interface;
using Movie.Management.Unit.Test.Configuration;
using Movie.Management.Unit.Test.Mocks;

namespace Movie.Management.Unit.Test.Service
{
    public class MoviesServiceTest : ConfigBase
    {
        private readonly Mock<IMovieRepository> _movieRepositoryMock;

        public MoviesServiceTest()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>();
        }

        private MoviesService GetService()
        {
            return new MoviesService(_movieRepositoryMock.Object, _mapper);
        }

        [Fact(DisplayName = "Get all movies from repository")]
        public async Task GetAllMovies_ShouldReturnMovies()
        {
            var moviesMock = MovieMock.MovieFaker.Generate(2);

            _movieRepositoryMock.Setup(x => x.GetAllAsync(0,25))
                .ReturnsAsync(moviesMock);

            var response = await GetService().GetAllMoviesAsync(0,25);

            var result = Assert.IsAssignableFrom<IEnumerable<MovieDto>>(response.Result);
            Assert.True(result.Count().Equals(2));
        }

        [Fact(DisplayName = "Get movie by Id from repository")]
        public async Task GetMovieById_ShouldReturnMovie()
        {
            var movieId = 1;
            var movieMock = MovieMock.MovieFaker.Generate();
            movieMock.Id = movieId;

            _movieRepositoryMock.Setup(x => x.GetByIdAsync(movieId))
                .ReturnsAsync(movieMock);

            var response = await GetService().GetMovieById(movieId);

            Assert.NotNull(response);
            Assert.IsType<MovieDto>(response.Result);
        }

        [Fact(DisplayName = "Get movie by non-existent movieId in repository")]
        public async Task GetMovieById_WhenMovieNotFound_ShouldReturnNull()
        {
            Movies? movieMock = null;
            var movieId = 1;

            _movieRepositoryMock.Setup(x => x.GetByIdAsync(movieId))
                .ReturnsAsync(movieMock);

            var response = await GetService().GetMovieById(movieId);

            Assert.Null(response.Result);
        }

        [Fact(DisplayName = "Create new movie in repository")]
        public async Task AddMoviesAsync_ShouldAddMovie()
        {
            var movieDtoMock = MovieMock.MovieDtoFaker.Generate();

            _movieRepositoryMock.Setup(x => x.Add(It.IsAny<Movies>()));

            var response = await GetService().AddMovieAsync(movieDtoMock);

            Assert.True(response.Success);
            Assert.False(response.Errors.Messages.Any());
        }

        [Fact(DisplayName = "Create new movie in repository with invalid year")]
        public async Task AddMoviesAsync_WhenYearIsInvalid_ShouldReturnError()
        {
            var movieDtoMock = MovieMock.MovieDtoFaker.Generate();
            movieDtoMock.Year = 23;

            _movieRepositoryMock.Setup(x => x.Add(movieDtoMock));

            var response = await GetService().AddMovieAsync(movieDtoMock);

            Assert.False(response.Success);
            Assert.True(response.Errors.Messages.Any());
        }
    }
}
