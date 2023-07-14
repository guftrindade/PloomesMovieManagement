using Bogus;
using Movie.Management.Api.ViewModel;
using Movie.Management.Domain.Helpers;
using Movie.Management.Domain.ModelDto;
using Movie.Management.Infra.Models;

namespace Movie.Management.Unit.Test.Mocks
{
    public static class MovieMock
    {
        public static Faker<MovieRequestViewModel> MovieRequestVMFaker =>
            new Faker<MovieRequestViewModel>()
            .CustomInstantiator(faker => new MovieRequestViewModel()
            {
                Title = "Star Wars: Episode I – The Phantom Menace",
                DirectedBy = "George Lucas",
                Year = 1999
            });

        public static Faker<MovieDto> MovieDtoFaker =>
            new Faker<MovieDto>()
            .CustomInstantiator(faker => new MovieDto()
            {
                Id = faker.Random.Number(1, 10),
                Title = "Star Wars: Episode I – The Phantom Menace",
                DirectedBy = "George Lucas",
                Year = 1999,
                CreatedDate = DateTime.UtcNow.AddHours(-3)
            });

        public static Faker<ResultOperation<MovieDto>> ResultOperationFaker =>
            new Faker<ResultOperation<MovieDto>>()
            .CustomInstantiator(faker => new ResultOperation<MovieDto>()
            {
                Result = MovieDtoFaker.Generate()
            });

        public static Faker<Movies> MovieFaker =>
            new Faker<Movies>()
            .CustomInstantiator(faker => new Movies()
            {
                Id = faker.Random.Number(1, 10),
                Title = "Star Wars: Episode I – The Phantom Menace",
                DirectedBy = "George Lucas",
                Year = 1999,
                CreatedDate = DateTime.UtcNow.AddHours(-3)
            });
    }
}
