using AutoMapper;
using FluxoCaixa.Comum.Notificacao;
using SaldoService.Application.DTOs;
using SaldoService.Application.MapDTOToDomain;
using SaldoService.Domain.Models;
using SaldoService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaldoService.Application.Services
{
    public class SaldoServices : ServicoBase, ISaldoServices
    {
        private readonly List<string> _notificacoes;

        public List<string> Notificacoes => _notificacoes;
        public bool IsValid => _notificacoes.Count == 0;

        public SaldoServices()
        {
            _notificacoes = new List<string>();
        }

        public void RegistraSaldo(SaldoDiarioDto saldoDiarioDto, ISaldoDiaRepository repo)
        {
            SaldoDia saldoDia = ObjectMapper.Mapper.Map<SaldoDia>(saldoDiarioDto);

            if (ValidarSaldoDia(saldoDia))
                repo.Adicionar(saldoDia);
        }

        private bool ValidarSaldoDia(SaldoDia saldoDia)
        {
            bool isValid = saldoDia.Saldo > 0;

            if (!isValid)
            {
                AdicionarNotificacao(this, "O valor da transação deve ser positivo.");
            }

            return isValid;
        }

        public SaldoDiarioDto ObterSaldoDiaPorData(DateTime Data, ISaldoDiaRepository repo)
        {
            var saldoDiario = repo.ObterSaldoDiaPorData(Data);

            SaldoDiarioDto saldoDiaDto = ObjectMapper.Mapper.Map<SaldoDiarioDto>(saldoDiario);

            return saldoDiaDto;
        }
    }
}
