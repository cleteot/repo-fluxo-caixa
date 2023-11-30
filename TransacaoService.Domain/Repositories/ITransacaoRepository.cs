using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacaoService.Domain.Models;

namespace TransacaoService.Domain.Repositories
{
    public interface ITransacaoRepository
    {
        Transacao ObterPorId(Guid id);
        IEnumerable<Transacao> ObterTodas();
        void Adicionar(Transacao transacao);

        IEnumerable<Transacao> ObterPorData(DateTime Data);
    }
}
