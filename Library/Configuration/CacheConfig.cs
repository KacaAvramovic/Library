using Microsoft.Extensions.DependencyInjection;

namespace LibraryApi.Configuration
{
    public static class CacheConfig
    {
        public static IServiceCollection AddInMemoryCache(this IServiceCollection services)
        {
            services.AddMemoryCache();

            return services;
        }
    }
}