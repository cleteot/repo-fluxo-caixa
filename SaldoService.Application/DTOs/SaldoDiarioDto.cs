using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoService.Application.DTOs
{
    public class SaldoDiarioDto
    {
        public Guid Id { get; set; }
        public DateTime Data {  get; set; }
        public decimal Saldo { get; set; }
    }
}
