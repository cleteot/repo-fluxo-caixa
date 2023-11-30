using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelatorioService.Application.Services;
using Serilog;

namespace RelatorioService.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioSaldoDiaService  _relatorioSaldoDiaService;
        public RelatorioController(IRelatorioSaldoDiaService relatorioSaldoDiaService)
        { 
            _relatorioSaldoDiaService = relatorioSaldoDiaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DateTime Data)
        {
            try
            {
                var retorno = await _relatorioSaldoDiaService.GetRelatorioSaldoDia(Data); 
               

                //if (_relatorioSaldoDiaService.IsValid)
                    return Ok(retorno);
                //else
                //    return BadRequest(new { Mensagem = "o Saldo não pode ser consultado devido a validação", Notificacoes = _saldoService.Notificacoes });

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao Relatório Saldo do Dia: {@Data}", Data);
                return StatusCode(500, "Erro interno ao processar a transação.");
            }
        }

    }
}
