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
    public class ContaGetTest
    {
        private ContasController _controller;

        [Fact(DisplayName = "É possível Realizar o GetOk.")]
        public async Task GetOk()
        {
            var serviceMock = new Mock<IContaService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                 new ContaDto
                 {
                     Id = Guid.NewGuid(),
                     Name = "PV Conta",
                     Description = "Conta Corrente",
                     Balance = 0,
                     Status = true
                 }
            );

            _controller = new ContasController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }

        [Fact(DisplayName = "É possível Realizar o GetBadRequest.")]
        public async Task GetBadRequest()
        {
            var serviceMock = new Mock<IContaService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                 new ContaDto
                 {
                     Id = Guid.NewGuid(),
                     Name = "PV Conta",
                     Description = "Conta Corrente",
                     Balance = 0,
                     Status = true
                 }
            );

            _controller = new ContasController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
