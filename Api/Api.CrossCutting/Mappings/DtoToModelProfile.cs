using Api.Domain.Dtos.Conta;
using Api.Domain.Dtos.Lancamento;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {

        public DtoToModelProfile()
        {
            CreateMap<ContaModel, ContaDto>().ReverseMap();

            CreateMap<ContaModel, ContaDtoCreate>().ReverseMap();

            CreateMap<ContaModel, ContaDtoUpdate>().ReverseMap();

            CreateMap<LancamentoModel, LancamentoDto>().ReverseMap();

            CreateMap<LancamentoModel, LancamentoDtoCreate>().ReverseMap();

        }
    }
}
