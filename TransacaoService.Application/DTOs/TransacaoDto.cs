using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoService.Application.DTOs
{
    public class TransacaoDto
    {
        public Guid Id { get; set; }
        public int TipoTransacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? Data { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
