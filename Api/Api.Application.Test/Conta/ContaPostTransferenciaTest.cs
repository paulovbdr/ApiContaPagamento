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
    public class ContaPostTransferenciaTest
    {
        private ContasController _controller;

        [Fact(DisplayName = "É possível Realizar o PostTransferCreated.")]
        public async Task PostTransferCreated()
        {
            var serviceMock = new Mock<IContaService>();

            serviceMock.Setup(m => m.PostTransfer(It.IsAny<ContaTransferenciaDtoCreate>())).ReturnsAsync(true);

            _controller = new ContasController(serviceMock.Object);


            var transferDtoCreate = new ContaTransferenciaDtoCreate
            {
                ContaIdOrigem = Guid.NewGuid(),
                ContaIdDestino = Guid.NewGuid(),
                ValorTransferencia = 100
            };

            var result = await _controller.PostTransfer(transferDtoCreate);
            Assert.True(result is OkObjectResult);
        }

        [Fact(DisplayName = "É possível Realizar o PostTransferBadRequest.")]
        public async Task PostTransferBadRequest()
        {
            var serviceMock = new Mock<IContaService>();

            serviceMock.Setup(m => m.PostTransfer(It.IsAny<ContaTransferenciaDtoCreate>())).ReturnsAsync(true);

            _controller = new ContasController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");


            var transferDtoCreate = new ContaTransferenciaDtoCreate
            {
                ContaIdOrigem = Guid.NewGuid(),
                ContaIdDestino = Guid.NewGuid(),
                ValorTransferencia = 100
            };

            var result = await _controller.PostTransfer(transferDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
