using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Lancamento;

namespace Api.Domain.Interfaces.Services
{
    public interface ILancamentoService
    {
        Task<LancamentoDto> Get(Guid id);

        Task<LancamentoDtoCreateResult> Post(LancamentoDtoCreate tipster);
    }
}
