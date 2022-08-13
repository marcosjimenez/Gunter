using GunterAPI.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

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

