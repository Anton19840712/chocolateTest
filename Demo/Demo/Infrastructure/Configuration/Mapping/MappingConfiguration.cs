using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure.Configuration.Mapping
{
    /// <summary>
    /// Configuration mapping.
    /// </summary>
    public static class MappingConfiguration
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new PersonMappingRules());
            });

            var mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}