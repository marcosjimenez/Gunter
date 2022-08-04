using GunterAPI.Domain.Services;
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
        public static IServiceCollection AddGunterApiDomain(this IServiceCollection services)
        {
            services.AddSingleton<ITextAnalysisService, TextAnalysisService>();
            services.AddSingleton<ITextToSentenceService, TextToSentenceService>();

            return services;
        }
    }
}

