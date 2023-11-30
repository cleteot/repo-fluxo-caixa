using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaldoService.Api.Models.Response;
using SaldoService.Application.DTOs;
using SaldoService.Application.Services;
using SaldoService.Domain.Repositories;
using Serilog;

namespace SaldoService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldoController : ControllerBase
    {
        private readonly ISaldoServices _saldoService;
        public readonly IMapper _mapper;
        private readonly ISaldoDiaRepository _repo;

        public SaldoController(ISaldoServices saldoServices, IMapper mapper, ISaldoDiaRepository repo) 
        { 
            _saldoService = saldoServices;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetSaldoDia(DateTime Data)
        {
            try
            {
                var saldoDto = _saldoService.ObterSaldoDiaPorData(Data, _repo);
                var saldoResp = _mapper.Map<SaldoDiaResp>(saldoDto);

                if (_saldoService.IsValid)
                    return Ok(saldoResp);
                else
                    return BadRequest(new { Mensagem = "o Saldo não pode ser consultado devido a validação", Notificacoes = _saldoService.Notificacoes });

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao consultar Saldo do Dia: {@Data}", Data);
                return StatusCode(500, "Erro interno ao processar a transação.");
            }
        }

    }
}
