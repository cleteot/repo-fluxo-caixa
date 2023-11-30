using FluxoCaixa.Comum.Rest;
using RelatorioService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioService.Application.Services
{
    public class RelatorioSaldoDiaService : IRelatorioSaldoDiaService
    {
        public async Task<RelatorioSaldoDiaDto> GetRelatorioSaldoDia(DateTime Data)
        {
            var saldoAnterior = await ConsultaSaldoAsync(Data.Date.AddDays(-1));
            var saldoAtual = await ConsultaSaldoAsync(Data.Date);
            var transacoesDia = await ConsultaTransacaoAsync(Data.Date);

            return new RelatorioSaldoDiaDto()
            {
                SaldoAnterior = saldoAnterior,
                SaldoAtual = saldoAtual,
                TransacaoCredito = transacoesDia?.Where(w => w.Tipo == 0).ToList(),
                TransacaoDebito = transacoesDia?.Where(w => w.Tipo == 1).ToList()
            };
        }

        private async Task<SaldoDiaDto> ConsultaSaldoAsync(DateTime Data) {
            RestClient restClient = new RestClient("http://localhost:59750");
            string resultGet = restClient.GetAsync("/api/Saldo?Data=" + Data.ToString("yyyy-MM-dd")).Result;

            var saldoDia = Newtonsoft.Json.JsonConvert.DeserializeObject<SaldoDiaDto>(resultGet);

            return saldoDia;
        }

        private async Task<List<TransacaoDiaDto>> ConsultaTransacaoAsync(DateTime Data)
        {
            RestClient restClient = new RestClient("https://localhost:44373");
            string resultGet = await restClient.GetAsync("/api/Transacao?Data=" + Data.ToString("yyyy-MM-dd"));

            var transacaoDia = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TransacaoDiaDto>>(resultGet);

            return transacaoDia;
        }
    }
}
