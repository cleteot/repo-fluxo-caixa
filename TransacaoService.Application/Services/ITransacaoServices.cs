using FluxoCaixa.Comum.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacaoService.Application.DTOs;
using TransacaoService.Domain.Repositories;

namespace TransacaoService.Application.Services
{
    public interface ITransacaoServices: IValidavel
    {
        void RegistrarTransacao(TransacaoDto transacao, IRabbitMQService rabbitMQ, ITransacaoRepository repo);
        List<TransacaoDto> ConsultaTransacaoPorData(DateTime Data, ITransacaoRepository repo);
    }
}
