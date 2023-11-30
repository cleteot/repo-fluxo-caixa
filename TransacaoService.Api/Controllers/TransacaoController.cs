using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TransacaoService.Api.Models.Request;
using TransacaoService.Application.DTOs;
using TransacaoService.Application.Services;
using TransacaoService.Domain.Models;
using TransacaoService.Domain.Repositories;

namespace TransacaoServiceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoServices _transacaoService;
        private readonly IRabbitMQService _rabbitmqService;
        public readonly IMapper _mapper;
        private readonly ITransacaoRepository _repo;

        public TransacaoController(ITransacaoServices transacaoService, IRabbitMQService rabbitMQ, IMapper mapper, ITransacaoRepository repo)
        {
            _transacaoService = transacaoService;
            _rabbitmqService = rabbitMQ;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult RegistrarTransacao([FromBody] RespTransacao transacao)
        {
            try
            {
                var trans = _mapper.Map<TransacaoDto>(transacao);
                _transacaoService.RegistrarTransacao(trans, _rabbitmqService, _repo);
                if (_transacaoService.IsValid)
                    return Ok("Transação registrada com sucesso.");
                else
                    return BadRequest(new { Mensagem = "A transação não pôde ser registrada devido a problemas de validação", Notificacoes = _transacaoService.Notificacoes });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao registrar transação: {@Transacao}", transacao);
                return StatusCode(500, "Erro interno ao processar a transação.");
            }
        }

        [HttpGet]
        public IActionResult GetTransacaoPorData(DateTime Data)
        {
            try
            {
                //var trans = _mapper.Map<TransacaoDto>(transacao);
                var retorno = _transacaoService.ConsultaTransacaoPorData(Data, _repo);
                if (_transacaoService.IsValid)
                    return Ok(retorno);
                else
                    return BadRequest(new { Mensagem = "A transação não pôde ser consultada devido a problemas de validação", Notificacoes = _transacaoService.Notificacoes });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Erro ao consultar transações: {@Data}", Data);
                return StatusCode(500, "Erro interno ao processar a transação.");
            }
        }
    }

}
