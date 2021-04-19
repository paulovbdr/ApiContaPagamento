using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IContaRepository : IRepository<ContaEntity>
    {
        Task<bool> InsertTransfer(ContaEntity contaOrigem, ContaEntity contaDestino, LancamentoEntity lancamentoDebito, LancamentoEntity lancamentoCredito);
    }
}
