using Microsoft.Extensions.DependencyInjection;

namespace EvolentHealth.Directory.Core.AspNet.Configuration.DependencyInjection
{
    public static class CommonServiceCollectionExtension
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services, bool isDevelopment)
        {
            services.AddApplicationInsightsTelemetry();
            return services;
        }
    }
}