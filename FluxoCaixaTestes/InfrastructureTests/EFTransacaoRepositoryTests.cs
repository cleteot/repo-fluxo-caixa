using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacaoService.Domain.Models;
using TransacaoService.Infrastructure;
using TransacaoService.Infrastructure.Repositories;

namespace FluxoCaixaTestes.InfrastructureTests
{
    public class EFTransacaoRepositoryTests
    {
        // Use um contexto de banco de dados em memória para os testes
        private readonly DbContextOptions<AppDbContext> _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        [Fact]
        public void Deve_Obter_Transacao_Por_Id_Com_Sucesso()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                var repository = new EFTransacaoRepository(context);
                
                context.Set<Transacao>().RemoveRange(context.Set<Transacao>());
                context.SaveChanges();

                var transacao = new Transacao
                {
                    Id = Guid.NewGuid(),
                    CategoriaId = Guid.NewGuid(),
                    Data = DateTime.Now,
                    TipoTransacao = Tipo.Credito,
                    Valor = 100.0m
                };
                context.Set<Transacao>().Add(transacao);
                context.SaveChanges();

                // Act
                var result = repository.ObterPorId(transacao.Id);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(transacao.Id, result.Id);
                // Adicione outras asserções conforme necessário

                context.Dispose();
            }
        }

        [Fact]
        public void Deve_Obter_Todas_As_Transacoes_Com_Sucesso()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                var repository = new EFTransacaoRepository(context);
                
                context.Set<Transacao>().RemoveRange(context.Set<Transacao>());
                context.SaveChanges();

                var transacoes = new List<Transacao>
                {
                    new Transacao
                    {
                        Id = Guid.NewGuid(),
                        CategoriaId = Guid.NewGuid(),
                        Data = DateTime.Now,
                        TipoTransacao = Tipo.Credito,
                        Valor = 100.0m
                    },
                    new Transacao
                    {
                        Id = Guid.NewGuid(),
                        CategoriaId = Guid.NewGuid(),
                        Data = DateTime.Now,
                        TipoTransacao = Tipo.Credito,
                        Valor = 200.0m
                    }
                    // Adicione mais transações conforme necessário
                };
                context.Set<Transacao>().AddRange(transacoes);
                context.SaveChanges();

                // Act
                var result = repository.ObterTodas();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(transacoes.Count, result.Count());
                // Adicione outras asserções conforme necessário

                context.Dispose();
            }
        }

        [Fact]
        public void Deve_Adicionar_Transacao_Com_Sucesso()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                var repository = new EFTransacaoRepository(context);
                context.Set<Transacao>().RemoveRange(context.Set<Transacao>());
                context.SaveChanges();

                var transacao = new Transacao
                {
                    Id = Guid.NewGuid(),
                    CategoriaId = Guid.NewGuid(),
                    Data = DateTime.Now,
                    TipoTransacao = Tipo.Credito,
                    Valor = 100.0m
                };

                // Act
                repository.Adicionar(transacao);

                // Assert
                var result = context.Set<Transacao>().Find(transacao.Id);
                Assert.NotNull(result);
                Assert.Equal(transacao.Id, result.Id);
                // Adicione outras asserções conforme necessário

                context.Dispose();
            }
        }
    }
}
