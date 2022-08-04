using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
