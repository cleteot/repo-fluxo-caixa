using consumidor_transacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SaldoService.Domain.Repositories;
using SaldoService.Infrastructure;
using SaldoService.Infrastructure.Repositories;
using System.Configuration;
using TransacaoService.Application;
using TransacaoService.Application.Services;
using TransacaoService.Domain.Repositories;
using TransacaoService.Infrastructure.Repositories;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices( (context, services) =>
    {
       
        services.Configure<RabbitMQConfig>(context.Configuration.GetSection("RabbitMQConfig"));
        services.AddSingleton<IRabbitMQService>(provider =>
        {
            IOptions<RabbitMQConfig> rabbitMQConfig = provider.GetRequiredService<IOptions<RabbitMQConfig>>();
            return new RabbitMQService(rabbitMQConfig);
        });
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

        services.AddSingleton<ISaldoDiaRepository, EFSaldoDiaRepository>();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
