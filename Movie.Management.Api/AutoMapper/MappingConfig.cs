using AutoMapper;
using Movie.Management.Api.ModelsDto;
using Movie.Management.Api.ViewModel;
using Movie.Management.Domain.ModelDto;
using Movie.Management.Infra.Models;

namespace Movie.Management.Api.AutoMapper
{
    public static class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<MovieRequestViewModel, MovieDto>();
                config.CreateMap<MovieDto, MovieResponseViewModel>();
                config.CreateMap<MovieDto, Movies>();
                config.CreateMap<Movies, MovieDto>();
                config.CreateMap<Movies, MovieResponseViewModel>();
            });

            return mappingConfig;
        }
    }
}
