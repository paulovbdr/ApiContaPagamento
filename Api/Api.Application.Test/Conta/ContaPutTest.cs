using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Conta;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Conta
{
    public class ContaPutTest
    {
        private ContasController _controller;

        [Fact(DisplayName = "É possível Realizar o Updated.")]
        public async Task UpdateOk()
        {
            var serviceMock = new Mock<IContaService>();
            serviceMock.Setup(m => m.Put(It.IsAny<ContaDtoUpdate>())).ReturnsAsync(
                new ContaDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = "PV Conta",
                    Description = "Conta Corrente",
                    Balance = 0,
                    Status = true,
                    UpdateAt = DateTime.Now
                }
            );

            _controller = new ContasController(serviceMock.Object);

            var contaDtoUpdate = new ContaDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = "PV Conta",
                Description = "Conta Corrente",
                Status = true
            };

            var result = await _controller.Put(contaDtoUpdate);
            Assert.True(result is OkObjectResult);

        }

        [Fact(DisplayName = "É possível Realizar o UpdateBadRequest.")]
        public async Task UpdateBadRequest()
        {
            var serviceMock = new Mock<IContaService>();
            serviceMock.Setup(m => m.Put(It.IsAny<ContaDtoUpdate>())).ReturnsAsync(
                new ContaDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Name = "PV Conta",
                    Description = "Conta Corrente",
                    Balance = 0,
                    Status = true,
                    UpdateAt = DateTime.Now
                }
            );

            _controller = new ContasController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var contaDtoUpdate = new ContaDtoUpdate
            {
                Id = Guid.NewGuid(),
                Name = "PV Conta",
                Description = "Conta Corrente",
                Status = true
            };

            var result = await _controller.Put(contaDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
