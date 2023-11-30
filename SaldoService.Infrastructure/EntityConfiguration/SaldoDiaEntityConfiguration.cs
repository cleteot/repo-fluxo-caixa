using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaldoService.Domain.Models;

namespace SaldoService.Infrastructure.EntityConfiguration
{
    public class SaldoDiaEntityConfiguration : IEntityTypeConfiguration<SaldoDia>
    {
        public void Configure(EntityTypeBuilder<SaldoDia> builder)
        {
            // Nome da tabela
            builder.ToTable("TB_SaldoDiario");

            // Chave primária
            builder.HasKey(t => t.Id);

            // Propriedades
            builder.Property(t => t.Data)
                   .IsRequired();

            builder.Property(t => t.Saldo)
                   .IsRequired();

            // Relacionamentos ou outras configurações específicas podem ser adicionados aqui
        }
    }
}
