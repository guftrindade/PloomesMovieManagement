using AutoMapper;
using Movie.Management.Api.ModelsDto;
using Movie.Management.Domain.ModelDto;
using Movie.Management.Infra.Models;

namespace Movie.Management.Api.AutoMapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<MovieRequestViewModel, MovieDto>();
                config.CreateMap<MovieDto, Movies>();
            });

            return mappingConfig;
        }
    }
}
