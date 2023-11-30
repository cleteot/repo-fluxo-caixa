using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TransacaoService.Application.Services;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using TransacaoService.Infrastructure;
using TransacaoService.Domain.Repositories;
using TransacaoService.Infrastructure.Repositories;

namespace TransacaoService.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransacaoApplication(this IServiceCollection services)
        {
            services.AddScoped<ITransacaoServices, TransacaoServices>();
            return services;
        }

        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQConfig>(configuration.GetSection("RabbitMQConfig"));
            services.AddTransient<IRabbitMQService, RabbitMQService>();
            return services;
        }

        public static IServiceCollection AddTransacaoRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            services.AddScoped<ITransacaoRepository, EFTransacaoRepository>();

            return services;
        }
    }
}
