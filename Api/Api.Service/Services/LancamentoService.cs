using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Lancamento;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class LancamentoService : ILancamentoService
    {
        private ILancamentoRepository _repository;
        private IContaRepository _repositoryConta;

        private readonly IMapper _mapper;
        public LancamentoService(ILancamentoRepository repository, IMapper mapper, IContaRepository repositoryConta)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryConta = repositoryConta;
        }
        public async Task<LancamentoDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<LancamentoDto>(entity);
        }

        public async Task<LancamentoDtoCreateResult> Post(LancamentoDtoCreate lancamento)
        {
            var contaEntity = await _repositoryConta.SelectAsync(lancamento.ContaId);

            if (contaEntity == null)
            {
                throw new Exception("Conta não encontrada!");
            }
            contaEntity.Balance += lancamento.Value;

            var model = _mapper.Map<LancamentoModel>(lancamento);
            var entity = _mapper.Map<LancamentoEntity>(model);
            var result = await _repository.InsertLancamento(entity, contaEntity);

            return _mapper.Map<LancamentoDtoCreateResult>(result);
        }
    }
}
