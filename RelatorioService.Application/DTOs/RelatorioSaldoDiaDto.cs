using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioService.Application.DTOs
{
    public class RelatorioSaldoDiaDto
    {
        public SaldoDiaDto SaldoAnterior { get; set; }
        public SaldoDiaDto SaldoAtual { get; set; }

        public List<TransacaoDiaDto> TransacaoCredito { get; set; }
        public List<TransacaoDiaDto> TransacaoDebito { get; set; }
    }

    public class SaldoDiaDto
    {
        public DateTime Data { get; set; }
        public decimal Saldo { get; set; }
    }

    public class TransacaoDiaDto
    {
        public int Tipo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }

    }
}
