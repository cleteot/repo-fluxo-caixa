using FluxoCaixa.Comum.Notificacao;
using SaldoService.Application.DTOs;
using SaldoService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoService.Application.Services
{
    public interface ISaldoServices: IValidavel
    {
        void RegistraSaldo(SaldoDiarioDto saldoDiarioDto, ISaldoDiaRepository repo);
        SaldoDiarioDto ObterSaldoDiaPorData(DateTime Data, ISaldoDiaRepository repo);
    }
}
