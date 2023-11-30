using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoService.Domain.Models
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public Tipo TipoTransacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? Data { get; set; }
        public Guid CategoriaId { get; set; }
    }

    public enum Tipo { Credito = 0, Debito = 1 }
}
