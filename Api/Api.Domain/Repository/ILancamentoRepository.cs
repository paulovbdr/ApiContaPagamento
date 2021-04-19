using System.Threading.Tasks;
using Api.Domain.Dtos.Lancamento;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface ILancamentoRepository : IRepository<LancamentoEntity>
    {


        Task<LancamentoEntity> InsertLancamento(LancamentoEntity lancamento, ContaEntity conta);
    }
}
