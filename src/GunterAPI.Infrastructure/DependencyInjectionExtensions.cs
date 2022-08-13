using Microsoft.Extensions.DependencyInjection;

namespace GunterAPI.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddGunterAPIInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}
