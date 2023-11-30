using Moq;
using SaldoService.Application.DTOs;
using SaldoService.Application.Services;
using SaldoService.Domain.Models;
using SaldoService.Domain.Repositories;
using Xunit;

namespace FluxoCaixaTestes.ApplicationTests
{
    public class SaldoServiceTests
    {
        [Fact]
        public void RegistraSaldo_ValidSaldo_AddToRepository()
        {
            // Arrange
            var saldoDiarioDto = new SaldoDiarioDto
            {
                Saldo = 100.0m
            };

            var mockRepo = new Mock<ISaldoDiaRepository>();
            var saldoService = new SaldoService.Application.Services.SaldoServices();

            // Act
            saldoService.RegistraSaldo(saldoDiarioDto, mockRepo.Object);

            // Assert
            Assert.Empty(saldoService.Notificacoes);
        }

        [Fact]
        public void RegistraSaldo_InvalidSaldo_DoNotAddToRepository()
        {
            // Arrange
            var saldoDiarioDto = new SaldoDiarioDto
            {
                Saldo = -100.0m // Exemplo de saldo inválido para teste
            };

            var mockRepo = new Mock<ISaldoDiaRepository>();
            var saldoService = new SaldoService.Application.Services.SaldoServices();

            // Act
            saldoService.RegistraSaldo(saldoDiarioDto, mockRepo.Object);

            // Assert
            Assert.NotEmpty(saldoService.Notificacoes);
        }

        [Fact]
        public void Deve_Obter_SaldoDia_Por_Data_Com_Sucesso()
        {
            // Arrange
            var repoMock = new Mock<ISaldoDiaRepository>();
            var data = new DateTime(2023, 1, 1);
            var saldoDiario = new SaldoDia { Data = data, Saldo = 100 };

            repoMock.Setup(repo => repo.ObterSaldoDiaPorData(data)).Returns(saldoDiario);

            var service = new SaldoService.Application.Services.SaldoServices();

            // Act
            var result = service.ObterSaldoDiaPorData(data, repoMock.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(data, result.Data);
            Assert.Equal(100, result.Saldo);
        }

        [Fact]
        public void Deve_Retornar_SaldoDia_Nulo_Se_Inexistente()
        {
            // Arrange
            var repoMock = new Mock<ISaldoDiaRepository>();
            var data = new DateTime(2023, 1, 1);

            repoMock.Setup(repo => repo.ObterSaldoDiaPorData(data)).Returns((SaldoDia)null);

            var service = new SaldoService.Application.Services.SaldoServices();

            // Act
            var result = service.ObterSaldoDiaPorData(data, repoMock.Object);

            // Assert
            Assert.Null(result);
        }
    }
}
