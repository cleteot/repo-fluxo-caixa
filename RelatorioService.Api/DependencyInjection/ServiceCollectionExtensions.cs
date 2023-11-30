using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RelatorioService.Application.Services;

namespace RelatorioService.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRelatorioServiceApplication(this IServiceCollection services)
        {
            services.AddScoped<IRelatorioSaldoDiaService, RelatorioSaldoDiaService>();
            return services;
        }
    }
}
