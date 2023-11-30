using RabbitMQ.Client;
using Microsoft.Extensions.Options;
using System.Text;
using RabbitMQ.Client.Events;

namespace TransacaoService.Application.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly RabbitMQConfig _rabbitMQConfig;
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService(IOptions<RabbitMQConfig> rabbitMQConfig)
        {
            _rabbitMQConfig = rabbitMQConfig.Value;

            _factory = new ConnectionFactory
            {
                HostName = _rabbitMQConfig.HostName,
                UserName = _rabbitMQConfig.UserName,
                Password = _rabbitMQConfig.Password,
                Ssl =
                {
                   ServerName = _rabbitMQConfig.HostName,
                   Enabled = true
                }
                // Adicione outras configurações conforme necessário
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void EnviarMensagem(string mensagem)
        {

            _channel.BasicPublish(
                exchange: _rabbitMQConfig.ExchangeName,
                routingKey: "",
                basicProperties: null,
                body: Encoding.UTF8.GetBytes(mensagem)
            );
        }

        public void ConsumirMensagens(Action<string> callback)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                callback.Invoke(message);
            };

            _channel.BasicConsume(queue: _rabbitMQConfig.QueueName, autoAck: true, consumer: consumer);
        }
    }
}
