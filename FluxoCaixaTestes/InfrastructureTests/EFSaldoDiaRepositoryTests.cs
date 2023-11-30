using Microsoft.EntityFrameworkCore;
using SaldoService.Domain.Models;
using SaldoService.Infrastructure;
using SaldoService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacaoService.Domain.Models;

namespace FluxoCaixaTestes.InfrastructureTests
{
    public class EFSaldoDiaRepositoryTests
    {
        // Use um contexto de banco de dados em memória para os testes
        private readonly DbContextOptions<AppDbContext> _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        [Fact]
        public void Deve_Adicionar_SaldoDia_Com_Sucesso()
        {
            using (var context = new AppDbContext(_options))
            {
                var repository = new EFSaldoDiaRepository(context);

                context.Set<SaldoDia>().RemoveRange(context.Set<SaldoDia>());
                context.SaveChanges();

                var saldoDia = new SaldoDia
                {
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now,
                    Saldo = 50.0m
                };

                repository.Adicionar(saldoDia);

                var result = context.Set<SaldoDia>().Find(saldoDia.Id);

                Assert.NotNull(result);
                Assert.Equal(saldoDia.Id, result.Id);
                // Adicione outras asserções conforme necessário
            }
        }

        [Fact]
        public void Deve_Atualizar_SaldoDia_Existente_Com_Sucesso()
        {
            using (var context = new AppDbContext(_options))
            {
                var repository = new EFSaldoDiaRepository(context);

                context.Set<SaldoDia>().RemoveRange(context.Set<SaldoDia>());
                context.SaveChanges();

                var saldoDia = new SaldoDia
                {
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now,
                    Saldo = 50.0m
                };
                repository.Adicionar(saldoDia);

                var saldoDiaNovo = new SaldoDia
                {
                    Id = Guid.NewGuid(),
                    Data = DateTime.Now,
                    Saldo = -13.30m
                };

                repository.Adicionar(saldoDiaNovo);

                var result = context.Set<SaldoDia>().FirstOrDefault(w => w.Data.Date == saldoDiaNovo.Data.Date);

                Assert.NotNull(result);
                Assert.Equal(36.7m, result.Saldo);
                // Adicione outras asserções conforme necessário
            }
        }
    }
}
