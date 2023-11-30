using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacaoService.Domain.Models;

namespace TransacaoService.Infrastructure.EntityConfiguration
{
    public class TransacaoEntityConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            // Nome da tabela
            builder.ToTable("TB_Transacao");

            // Chave primária
            builder.HasKey(t => t.Id);

            // Propriedades
            builder.Property(t => t.TipoTransacao)
                   .IsRequired()
                   .HasColumnName("Tipo");
 
            builder.Property(t => t.Valor)
                   .IsRequired();

            builder.Property(t => t.Data)
                   .IsRequired();

            builder.Property(t => t.CategoriaId)
                   .IsRequired();

            // Relacionamentos ou outras configurações específicas podem ser adicionados aqui
        }
    }
}
