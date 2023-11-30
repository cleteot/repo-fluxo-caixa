using SaldoService.Domain.Models;
using SaldoService.Domain.Repositories;

namespace SaldoService.Infrastructure.Repositories
{
    public class EFSaldoDiaRepository : ISaldoDiaRepository
    {
        private readonly AppDbContext _dbContext;

        public EFSaldoDiaRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Adicionar(SaldoDia saldodia)
        {
            _dbContext.AddOrUpdate(saldodia);
            _dbContext.SaveChanges();
        }

        public SaldoDia ObterSaldoDiaPorData (DateTime Data)
        {
            var saldoDia = _dbContext.SaldoDiaEntity.Where(w =>  w.Data <= Data).OrderByDescending(o => o.Data).FirstOrDefault();
            return saldoDia;
        }
    }
}
