using Api.Domain.Dtos.Conta;
using Api.Domain.Dtos.Lancamento;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<ContaDto, ContaEntity>().ReverseMap();

            CreateMap<ContaDtoCreateResult, ContaEntity>().ReverseMap();

            CreateMap<ContaDtoUpdateResult, ContaEntity>().ReverseMap();

            CreateMap<ContaDtoBalance, ContaEntity>().ReverseMap();

            CreateMap<LancamentoDto, LancamentoEntity>().ReverseMap();

            CreateMap<LancamentoDtoCreateResult, LancamentoEntity>().ReverseMap();

        }
    }
}
