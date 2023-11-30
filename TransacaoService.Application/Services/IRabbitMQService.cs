using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoService.Application.Services
{
    public interface IRabbitMQService
    {
        void EnviarMensagem(string mensagem);
        void ConsumirMensagens(Action<string> callback);
    }
}
