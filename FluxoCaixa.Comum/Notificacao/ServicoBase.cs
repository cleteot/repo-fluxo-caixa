using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Comum.Notificacao
{
    public class ServicoBase
    {
         protected void AdicionarNotificacao(IValidavel validavel, string mensagem)
        {
            validavel.Notificacoes.Add(mensagem);
        }
    }
}
