using AutoMapper;
using Movie.Management.Api.ViewModel;
using Movie.Management.Domain.ModelDto;
using Movie.Management.Infra.Models;

namespace Movie.Management.Api.AutoMapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<MovieRequestViewModel, MovieDto>();
            CreateMap<MovieDto, MovieResponseViewModel>();
            CreateMap<MovieDto, Movies>();
            CreateMap<Movies, MovieDto>();
            CreateMap<MovieDto, MovieResponseViewModel>();
            CreateMap<MoviePaginatedDto, MovieResponsePaginatedViewModel>();
        }
    }
}
