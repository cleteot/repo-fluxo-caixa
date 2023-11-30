using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacaoService.Domain.Models;
using TransacaoService.Infrastructure.EntityConfiguration;

namespace TransacaoService.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transacao> TransacaoEntity { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações usando Fluent API
            modelBuilder.ApplyConfiguration(new TransacaoEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
