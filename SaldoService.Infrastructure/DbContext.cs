using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SaldoService.Domain.Models;
using SaldoService.Infrastructure.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SaldoService.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<SaldoDia> SaldoDiaEntity { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações usando Fluent API
            modelBuilder.ApplyConfiguration(new SaldoDiaEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public EntityEntry<SaldoDia> AddOrUpdate(SaldoDia entity)
        {
            var existingEntity = SaldoDiaEntity.FirstOrDefault(e => e.Data.Date == entity.Data.Date);

            if (existingEntity != null)
            {
                // Se a entidade já existe, soma o saldo
                existingEntity.Saldo += entity.Saldo;
                return Entry(existingEntity);
            }
            else
            {
                entity.Id = Guid.NewGuid();
                // Se a entidade não existe, adiciona a nova entidade
                return SaldoDiaEntity.Add(entity);
            }
        }
    }
}
