using SaldoService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoService.Domain.Repositories
{
    public interface ISaldoDiaRepository
    {
        SaldoDia ObterSaldoDiaPorData(DateTime Data);
        void Adicionar(SaldoDia saldodia);
    }
}
