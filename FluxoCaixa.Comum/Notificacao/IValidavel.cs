using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Comum.Notificacao
{
    public interface IValidavel
    {
        public List<string> Notificacoes { get; }
        public bool IsValid { get; }
    }
}
