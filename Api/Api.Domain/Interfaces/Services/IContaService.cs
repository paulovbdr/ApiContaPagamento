using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Conta;

namespace Api.Domain.Interfaces.Services
{
    public interface IContaService
    {
        Task<ContaDto> Get(Guid id);

        Task<IEnumerable<ContaDto>> GetAll();

        Task<ContaDtoCreateResult> Post(ContaDtoCreate tipster);
        Task<ContaDtoUpdateResult> Put(ContaDtoUpdate tipster);

        Task<bool> Delete(Guid id);

        Task<ContaDtoBalance> GetBalance(Guid id);

        Task<bool> PostTransfer(ContaTransferenciaDtoCreate transferencia);
    }
}
