using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Conta;

namespace Api.Service.Test.Conta
{
    public class ContaTestes
    {
        public static Guid Id { get; set; }

        public static string Name { get; set; }

        public static string Description { get; set; }
        public static decimal Balance { get; set; }
        public static bool Status { get; set; }

        public List<ContaDto> listaContaDto = new List<ContaDto>();
        public ContaDto contaDto;
        public ContaDtoCreate contaDtoCreate;
        public ContaDtoCreateResult contaDtoCreateResult;
        public ContaDtoUpdate contaDtoUpdate;
        public ContaDtoUpdateResult contaDtoUpdateResult;

        public ContaTestes()
        {
            Id = Guid.NewGuid();
            Name = Faker.Name.FullName();
            Description = "Conta Corrente";
            Balance = 0;
            Status = true;

            for (int i = 0; i < 10; i++)
            {
                var dto = new ContaDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Description = "Conta Corrente",
                    Balance = 0,
                    Status = true
                };
                listaContaDto.Add(dto);
            }

            contaDto = new ContaDto
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Balance = Balance,
                Status = Status
            };

            contaDtoCreate = new ContaDtoCreate
            {
                Name = Name,
                Description = Description,
                Status = Status
            };

            contaDtoCreateResult = new ContaDtoCreateResult
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Status = Status,
                Balance = Balance,
                CreateAt = DateTime.UtcNow
            };

            contaDtoUpdate = new ContaDtoUpdate
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Status = Status,
            };

            contaDtoUpdateResult = new ContaDtoUpdateResult
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Status = Status,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
