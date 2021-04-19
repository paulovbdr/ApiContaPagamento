using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Lancamento;

namespace Api.Service.Test.Lancamento
{
    public class LancamentoTestes
    {
        public static Guid Id { get; set; }
        public static Guid ContaId { get; set; }
        public static string Description { get; set; }
        public static decimal Value { get; set; }


        public List<LancamentoDto> listaLancamentoDto = new List<LancamentoDto>();
        public LancamentoDto lancamentoDto;
        public LancamentoDtoCreate lancamentoDtoCreate;
        public LancamentoDtoCreateResult lancamentoDtoCreateResult;


        public LancamentoTestes()
        {
            Id = Guid.NewGuid();
            ContaId = Guid.NewGuid();
            Description = "Lançamento de crédito";
            Value = Faker.RandomNumber.Next(1, 1000);

            for (int i = 0; i < 10; i++)
            {
                var dto = new LancamentoDto()
                {
                    Id = Guid.NewGuid(),
                    ContaId = Guid.NewGuid(),
                    Description = "Lançamento de crédito",
                    Value = Faker.RandomNumber.Next(1, 1000)
                };
                listaLancamentoDto.Add(dto);
            }

            lancamentoDto = new LancamentoDto
            {
                Id = Id,
                ContaId = ContaId,
                Description = Description,
                Value = Value
            };

            lancamentoDtoCreate = new LancamentoDtoCreate
            {
                ContaId = ContaId,
                Description = Description,
                Value = Value
            };

            lancamentoDtoCreateResult = new LancamentoDtoCreateResult
            {
                Id = Id,
                ContaId = ContaId,
                Description = Description,
                Value = Value,
                CreateAt = DateTime.UtcNow
            };

        }
    }
}
