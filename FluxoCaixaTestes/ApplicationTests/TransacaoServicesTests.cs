using Moq;
using TransacaoService.Application.DTOs;
using TransacaoService.Application.Services;
using TransacaoService.Domain.Repositories;
using Xunit;

namespace FluxoCaixaTestes.ApplicationTests
{
    public class TransacaoServicesTests
    {

        [Fact]
        public void RegistrarTransacao_ValidTransaction_NoNotifications()
        {
            // Arrange
            var transacao = new TransacaoDto { Valor = 100.0m };
            var rabbitMQMock = new Mock<IRabbitMQService>();
            var repoMock = new Mock<ITransacaoRepository>();
            var transacaoService = new TransacaoService.Application.Services.TransacaoServices();

            // Act
            transacaoService.RegistrarTransacao(transacao, rabbitMQMock.Object, repoMock.Object);

            // Assert
            Assert.Empty(transacaoService.Notificacoes);
        }

        [Fact]
        public void RegistrarTransacao_InvalidTransaction_WithNotifications()
        {
            // Arrange
            var transacao = new TransacaoDto { Valor = -100.0m }; // Exemplo de transação inválida
            var rabbitMQMock = new Mock<IRabbitMQService>();
            var repoMock = new Mock<ITransacaoRepository>();
            var transacaoService = new TransacaoService.Application.Services.TransacaoServices();

            // Act
            transacaoService.RegistrarTransacao(transacao, rabbitMQMock.Object, repoMock.Object);

            // Assert
            Assert.NotEmpty(transacaoService.Notificacoes);
        }
    }
}
