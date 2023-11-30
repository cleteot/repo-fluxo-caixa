using FluxoCaixa.Comum.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TransacaoService.Application.DTOs;
using TransacaoService.Application.MapDTOToDomain;
using TransacaoService.Domain.Models;
using TransacaoService.Domain.Repositories;

namespace TransacaoService.Application.Services
{
    public class TransacaoServices: ServicoBase, ITransacaoServices
    {
        private readonly List<string> _notificacoes;

        public List<string> Notificacoes => _notificacoes;

        public bool IsValid => _notificacoes.Count == 0;

        public TransacaoServices()
        {
            _notificacoes = new List<string>();
        }

        public void RegistrarTransacao(TransacaoDto transacaoDto, IRabbitMQService rabbitMQ, ITransacaoRepository repo)
        {
            Transacao transacao = ObjectMapper.Mapper.Map<Transacao>(transacaoDto);

            if (ValidarTransacao(transacao))
            {
                transacao.Id = Guid.NewGuid();
                repo.Adicionar(transacao);

                Console.WriteLine($"Registrando transação: {transacao.Id}, Valor: {transacao.Valor}");

                rabbitMQ.EnviarMensagem(Newtonsoft.Json.JsonConvert.SerializeObject(transacao));
            }
        }

        private bool ValidarTransacao(Transacao transacao)
        {
            // Lógica de negócio para validar a transação (por exemplo, valor positivo)
            bool isValid = transacao.Data != null;

            if (!isValid)
            {
                AdicionarNotificacao(this, "A data deve ser informada.");
            }

            return isValid;
        }

        public List<TransacaoDto> ConsultaTransacaoPorData(DateTime Data, ITransacaoRepository repo)
        {
            var transacoes = repo.ObterPorData(Data);
            List<TransacaoDto> transacaoDto = ObjectMapper.Mapper.Map<List<TransacaoDto>>(transacoes);

            return transacaoDto;

        }
    }
}
