using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Json;
using Serilog.Formatting;
using Serilog.Sinks.Splunk;
using Newtonsoft;
using Microsoft.Extensions.DependencyInjection;
using TransacaoService.Application.DependencyInjection;
using TransacaoService.Application;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .WriteTo.Console()
        // Adicione outras configurações do Serilog aqui, como escrever para arquivos, etc.
        .WriteTo.Http(
                    requestUri: "http://seu-splunk-host:8088",
                    textFormatter: new Serilog.Formatting.Compact.RenderedCompactJsonFormatter(),
                    queueLimitBytes: 1024)
                .MinimumLevel.Information()
                .Enrich.FromLogContext();
    
});

builder.Services.AddTransacaoApplication();
builder.Services.AddTransacaoRepository(configuration: builder.Configuration);
builder.Services.AddRabbitMQ(configuration: builder.Configuration);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();
