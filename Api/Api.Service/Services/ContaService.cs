using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Conta;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class ContaService : IContaService
    {
        private IContaRepository _repository;

        private readonly IMapper _mapper;

        public ContaService(IContaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ContaDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ContaDto>(entity);
        }

        public async Task<IEnumerable<ContaDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<ContaDto>>(listEntity);
        }

        public async Task<ContaDtoCreateResult> Post(ContaDtoCreate conta)
        {
            var model = _mapper.Map<ContaModel>(conta);
            var entity = _mapper.Map<ContaEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<ContaDtoCreateResult>(result);
        }

        public async Task<ContaDtoUpdateResult> Put(ContaDtoUpdate conta)
        {
            var model = _mapper.Map<ContaModel>(conta);
            var entity = _mapper.Map<ContaEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<ContaDtoUpdateResult>(result);
        }

        public async Task<ContaDtoBalance> GetBalance(Guid id)
        {
            var entity = await _repository.SelectAsync(id);

            return _mapper.Map<ContaDtoBalance>(entity);
        }

        public async Task<bool> PostTransfer(ContaTransferenciaDtoCreate transferencia)
        {
            var contaOrigem = await _repository.SelectAsync(transferencia.ContaIdOrigem);

            if (contaOrigem == null)
            {
                throw new Exception("Conta do remetente não encontrada!");
            }

            var contaDestino = await _repository.SelectAsync(transferencia.ContaIdDestino);

            if (contaDestino == null)
            {
                throw new Exception("Conta de destino não encontrada!");
            }

            contaOrigem.Balance -= transferencia.ValorTransferencia;
            contaDestino.Balance += transferencia.ValorTransferencia;

            LancamentoEntity lancamentoDebito = new LancamentoEntity();
            LancamentoEntity lancamentoCredito = new LancamentoEntity();

            lancamentoDebito.Id = Guid.NewGuid();
            lancamentoDebito.ContaId = contaOrigem.Id;
            lancamentoDebito.Value = transferencia.ValorTransferencia;
            lancamentoDebito.Description = $"Transfência entre contas - CC Destino: {contaDestino.Id} R$: {transferencia.ValorTransferencia}";

            lancamentoCredito.Id = Guid.NewGuid();
            lancamentoCredito.ContaId = contaDestino.Id;
            lancamentoCredito.Value = transferencia.ValorTransferencia;
            lancamentoCredito.Description = $"Transfência entre contas - CC Origem: {contaOrigem.Id} R$: {transferencia.ValorTransferencia}";

            var result = await _repository.InsertTransfer(contaOrigem, contaDestino, lancamentoDebito, lancamentoCredito);

            return result;
        }
    }
}
