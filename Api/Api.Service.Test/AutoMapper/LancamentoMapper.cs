using System;
using Api.Domain.Dtos.Lancamento;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class LancamentoMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelo de Lancamento")]
        public void Map_Lancamento()
        {
            var model = new LancamentoModel
            {
                Id = Guid.NewGuid(),
                ContaId = Guid.NewGuid(),
                Description = "Lançamento de Crédito",
                Value = 100,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            //Model => Entity
            var entity = Mapper.Map<LancamentoEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.ContaId, model.ContaId);
            Assert.Equal(entity.Description, model.Description);
            Assert.Equal(entity.Value, model.Value);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity para Dto
            var lancamentoDto = Mapper.Map<LancamentoDto>(entity);
            Assert.Equal(lancamentoDto.Id, entity.Id);
            Assert.Equal(lancamentoDto.ContaId, entity.ContaId);
            Assert.Equal(lancamentoDto.Description, entity.Description);
            Assert.Equal(lancamentoDto.Value, entity.Value);

            //Dto para Model
            var lancamentoModel = Mapper.Map<LancamentoDto>(model);
            Assert.Equal(lancamentoDto.Id, entity.Id);
            Assert.Equal(lancamentoDto.ContaId, entity.ContaId);
            Assert.Equal(lancamentoDto.Description, entity.Description);
            Assert.Equal(lancamentoDto.Value, entity.Value);
        }
    }
}
