using System;
using Api.Domain.Dtos.Conta;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class ContaMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelo de Conta")]
        public void Map_Conta()
        {
            var model = new ContaModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Description = "Conta Corrente",
                Status = true,
                Balance = 0,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            //Model => Entity
            var entity = Mapper.Map<ContaEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Description, model.Description);
            Assert.Equal(entity.Status, model.Status);
            Assert.Equal(entity.Balance, model.Balance);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity para Dto
            var contaDto = Mapper.Map<ContaDto>(entity);
            Assert.Equal(contaDto.Id, entity.Id);
            Assert.Equal(contaDto.Name, entity.Name);
            Assert.Equal(contaDto.Description, entity.Description);

            //Dto para Model
            var contaModel = Mapper.Map<ContaDto>(model);
            Assert.Equal(contaModel.Id, model.Id);
            Assert.Equal(contaModel.Name, model.Name);
            Assert.Equal(contaModel.Description, model.Description);
        }
    }
}
