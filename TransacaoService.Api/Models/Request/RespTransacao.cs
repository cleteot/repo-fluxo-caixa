using TransacaoService.Domain.Models;

namespace TransacaoService.Api.Models.Request
{
    public class RespTransacao
    {
        public int TipoTransacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? Data { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
