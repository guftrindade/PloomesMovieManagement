using Microsoft.AspNetCore.Mvc;
using Moq;
using Movie.Management.Domain.ModelDto;
using Movie.Management.Domain.Service;
using Movie.Management.Domain.Service.Interface;
using Movie.Management.Infra.Models;
using Movie.Management.Infra.Repository.Interface;
using Movie.Management.Unit.Test.Configuration;
using Movie.Management.Unit.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Fact]
        public async Task GetAllMovies_ShouldReturnMovies()
        {
            var moviesMock = MovieMock.MovieFaker.Generate(2);

            _movieRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(moviesMock);

            var response = await GetService().GetAllMoviesAsync();

            var result = Assert.IsAssignableFrom<IEnumerable<MovieDto>>(response);
            Assert.True(result.Count().Equals(2));
        }

        [Fact]
        public async Task GetMovieById_ShouldReturnMovie()
        {
            var movieId = 1;
            var movieMock = MovieMock.MovieFaker.Generate();
            movieMock.Id = movieId;

            _movieRepositoryMock.Setup(x => x.GetByIdAsync(movieId))
                .ReturnsAsync(movieMock);

            var response = await GetService().GetMovieById(movieId);

            Assert.NotNull(response);
            Assert.IsType<MovieDto>(response);
        }

        [Fact]
        public async Task GetMovieById_WhenMovieNotFound_ShouldReturnNull()
        {
            Movies? movieMock = null;
            var movieId = 1;

            _movieRepositoryMock.Setup(x => x.GetByIdAsync(movieId))
                .ReturnsAsync(movieMock);

            var response = await GetService().GetMovieById(movieId);

            Assert.Null(response);
        }

        [Fact]
        public async Task AddMoviesAsync_ShouldAddMovie()
        {
            var movieDtoMock = MovieMock.MovieDtoFaker.Generate();

            _movieRepositoryMock.Setup(x => x.Add(It.IsAny<Movies>()));

            var response = await GetService().AddMovieAsync(movieDtoMock);

            Assert.True(response.Success);
            Assert.False(response.Errors.Mensagens.Any());
        }

        [Fact]
        public async Task AddMoviesAsync_WhenYearIsInvalid_ShouldReturnError()
        {
            var movieDtoMock = MovieMock.MovieDtoFaker.Generate();
            movieDtoMock.Year = 23;

            _movieRepositoryMock.Setup(x => x.Add(movieDtoMock));

            var response = await GetService().AddMovieAsync(movieDtoMock);

            Assert.False(response.Success);
            Assert.True(response.Errors.Mensagens.Any());
        }
    }
}
