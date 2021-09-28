using AutoMapper;
using LibraryApi.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApi.Configuration
{
    public static class CorsConfig
    {
        public static IServiceCollection AddCorsPolicies(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: policyName,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44322")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            return services;
        }
    }
}