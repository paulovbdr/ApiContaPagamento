using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Api.Data.Implementations
{
    public class ContaImplementation : BaseRepository<ContaEntity>, IContaRepository
    {
        private DbSet<ContaEntity> _dataset;
        public ContaImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ContaEntity>();
        }

        public async Task<bool> InsertTransfer(ContaEntity contaOrigem, ContaEntity contaDestino, LancamentoEntity lancamentoDebito, LancamentoEntity lancamentoCredito)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _dataset.Update(contaOrigem);
                    _dataset.Update(contaDestino);

                    _context.Entry(lancamentoDebito).State = EntityState.Added;
                    _context.Entry(lancamentoCredito).State = EntityState.Added;

                    await _context.SaveChangesAsync();

                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
