using RelatorioService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioService.Application.Services
{
    public interface IRelatorioSaldoDiaService
    {
        Task<RelatorioSaldoDiaDto> GetRelatorioSaldoDia(DateTime Data);
    }
}
