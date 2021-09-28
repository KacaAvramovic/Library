using AutoMapper;
using LibraryApi.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApi.Configuration
{
    public static class MapperConfig
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}