using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoService.Domain.Models
{
    public class SaldoDia
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Saldo { get; set; }

    }
}
