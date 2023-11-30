using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransacaoService.Domain.Models;
using TransacaoService.Domain.Repositories;

namespace TransacaoService.Infrastructure.Repositories
{
    public class EFTransacaoRepository : ITransacaoRepository
    {
        private readonly AppDbContext _dbContext;

        public EFTransacaoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Transacao ObterPorId(Guid id)
        {
            return _dbContext.Set<Transacao>().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Transacao> ObterTodas()
        {
            return _dbContext.Set<Transacao>().ToList();
        }

        public void Adicionar(Transacao transacao)
        {
            _dbContext.Set<Transacao>().Add(transacao);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Transacao> ObterPorData(DateTime Data)
        {
            var lista = _dbContext.TransacaoEntity.Where(w => w.Data.HasValue && w.Data.Value.Date == Data.Date).Select(s => 
                new Transacao
                {
                    Id = s.Id,
                    //CategoriaId = s.CategoriaId,
                    Data = s.Data,
                    TipoTransacao = s.TipoTransacao,
                    Valor = s.Valor
                }
                );
            return lista;
        }
    }
}
