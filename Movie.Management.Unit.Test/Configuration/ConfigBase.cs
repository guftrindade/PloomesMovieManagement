using AutoMapper;
using Movie.Management.Api.AutoMapper;

namespace Movie.Management.Unit.Test.Configuration
{
    public class ConfigBase
    {
        public readonly IMapper _mapper;

        public ConfigBase()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingConfig());
                });

                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
    }
}
