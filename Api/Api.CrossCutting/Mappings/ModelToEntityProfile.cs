using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<ContaEntity, ContaModel>().ReverseMap();

            CreateMap<LancamentoEntity, LancamentoModel>().ReverseMap();

        }
    }
}
