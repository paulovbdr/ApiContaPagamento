using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Dtos.Lancamento;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class LancamentoImplementation : BaseRepository<LancamentoEntity>, ILancamentoRepository
    {
        private DbSet<LancamentoEntity> _dataset;
        public LancamentoImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<LancamentoEntity>(); ;
        }

        public async Task<LancamentoEntity> InsertLancamento(LancamentoEntity lancamento, ContaEntity conta)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (lancamento.Id == Guid.Empty)
                    {
                        lancamento.Id = Guid.NewGuid();
                    }

                    lancamento.CreateAt = DateTime.UtcNow;
                    _dataset.Add(lancamento);

                    _context.Entry(conta).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return lancamento;
        }
    }
}
