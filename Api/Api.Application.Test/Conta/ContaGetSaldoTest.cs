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
    public class ContaGetSaldoTest
    {
        private ContasController _controller;

        [Fact(DisplayName = "É possível Realizar o GetSaldoOk.")]
        public async Task GetSaldoOk()
        {
            var serviceMock = new Mock<IContaService>();

            serviceMock.Setup(m => m.GetBalance(It.IsAny<Guid>())).ReturnsAsync(
                 new ContaDtoBalance
                 {
                     Balance = 100
                 }
            );

            _controller = new ContasController(serviceMock.Object);
            var result = await _controller.GetSaldo(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }

        [Fact(DisplayName = "É possível Realizar o GetSaldoBadRequest.")]
        public async Task GetSaldoBadRequest()
        {
            var serviceMock = new Mock<IContaService>();

            serviceMock.Setup(m => m.GetBalance(It.IsAny<Guid>())).ReturnsAsync(
                 new ContaDtoBalance
                 {
                     Balance = 100
                 }
            );

            _controller = new ContasController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.GetSaldo(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
