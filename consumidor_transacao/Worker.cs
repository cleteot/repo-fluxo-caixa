using SaldoService.Domain.Models;
using SaldoService.Domain.Repositories;
using System.Runtime.CompilerServices;
using TransacaoService.Application.Services;
using TransacaoService.Domain.Models;

namespace consumidor_transacao
{
    public class Worker : BackgroundService
    {
        //private readonly ILogger<Worker> _logger;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly ISaldoDiaRepository _repo;

        public Worker(IRabbitMQService rabbitMQService, ISaldoDiaRepository repo)
        {
            _rabbitMQService = rabbitMQService;
            _repo = repo;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _rabbitMQService.ConsumirMensagens(ProcessarMensagem);

            while (!stoppingToken.IsCancellationRequested)
            {
                
                // Lógica do Worker
                await Task.Delay(1000, stoppingToken);
            }
        }

        private void ProcessarMensagem(string mensagem)
        {
            // Lógica para processar a mensagem do RabbitMQ e chamar a API
            Console.WriteLine($"Mensagem recebida: {mensagem}");
            Transacao trans = Newtonsoft.Json.JsonConvert.DeserializeObject<Transacao>(mensagem);
            // Chamar a API para consolidar o saldo do dia

            SaldoDia saldoDia = new()
            {
                Saldo = trans.Valor,
                Data = trans.Data.Value
            };

            _repo.Adicionar(saldoDia);
            
        }
    }
}