using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SaldoService.Application.Services;
using SaldoService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SaldoService.Domain.Repositories;
using SaldoService.Infrastructure.Repositories;

namespace SaldoService.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSaldoServiceApplication(this IServiceCollection services)
        {
            services.AddScoped<ISaldoServices, SaldoServices>();
            return services;
        }

        public static IServiceCollection AddSaldoDiaRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            services.AddScoped<ISaldoDiaRepository, EFSaldoDiaRepository>();

            return services;
        }
    }
}
