using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Conta;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Conta
{
    public class ContaGetAllTest
    {
        private ContasController _controller;

        [Fact(DisplayName = "É possível Realizar o GetAllOk.")]
        public async Task GetAllOk()
        {
            var serviceMock = new Mock<IContaService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                 new List<ContaDto>
                 {
                    new ContaDto
                    {
                        Id = Guid.NewGuid(),
                     Name = "PV Conta",
                     Description = "Conta Corrente",
                     Balance = 0,
                     Status = true
                    },
                    new ContaDto
                    {
                       Id = Guid.NewGuid(),
                     Name = "PV Conta",
                     Description = "Conta Corrente",
                     Balance = 0,
                     Status = true
                    }
                 }
            );

            _controller = new ContasController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);
        }

        [Fact(DisplayName = "É possível Realizar o GetAllBadRequest.")]
        public async Task GetAllBadRequest()
        {
            var serviceMock = new Mock<IContaService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                 new List<ContaDto>
                 {
                    new ContaDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "PV Conta",
                        Description = "Conta Corrente",
                        Balance = 0,
                        Status = true
                    },
                    new ContaDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "PV Conta",
                        Description = "Conta Corrente",
                        Balance = 0,
                        Status = true
                    }
                 }
            );

            _controller = new ContasController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
