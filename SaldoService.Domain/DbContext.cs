using Microsoft.EntityFrameworkCore;
using SaldoService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SaldoService.Domain
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
    }
}
