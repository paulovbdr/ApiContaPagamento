using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Lancamento;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Lancamento
{
    public class LancamentoTest
    {
        private LancamentosController _controller;

        [Fact(DisplayName = "É possível Realizar o GetOk.")]
        public async Task GetOk()
        {
            var serviceMock = new Mock<ILancamentoService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                 new LancamentoDto
                 {
                     Id = Guid.NewGuid(),
                     ContaId = Guid.NewGuid(),
                     Description = "Crédito",
                     Value = 100
                 }
            );

            _controller = new LancamentosController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }

        [Fact(DisplayName = "É possível Realizar o GetBadRequest.")]
        public async Task GetBadRequest()
        {
            var serviceMock = new Mock<ILancamentoService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                 new LancamentoDto
                 {
                     Id = Guid.NewGuid(),
                     ContaId = Guid.NewGuid(),
                     Description = "Crédito",
                     Value = 100
                 }
            );

            _controller = new LancamentosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "É possível Realizar o GetNotFound.")]
        public async Task GetNotFound()
        {
            var serviceMock = new Mock<ILancamentoService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((LancamentoDto)null));

            _controller = new LancamentosController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }

        [Fact(DisplayName = "É possível Realizar o PostCreated.")]
        public async Task PostCreated()
        {
            var serviceMock = new Mock<ILancamentoService>();

            serviceMock.Setup(m => m.Post(It.IsAny<LancamentoDtoCreate>())).ReturnsAsync(
                 new LancamentoDtoCreateResult
                 {
                     Id = Guid.NewGuid(),
                     ContaId = Guid.NewGuid(),
                     Description = "Crédito",
                     Value = 100,
                     CreateAt = DateTime.Now
                 }
            );

            _controller = new LancamentosController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var lancamentoDtoCreate = new LancamentoDtoCreate
            {
                ContaId = Guid.NewGuid(),
                Description = "Crédito",
                Value = 100
            };

            var result = await _controller.Post(lancamentoDtoCreate);
            Assert.True(result is CreatedResult);
        }

        [Fact(DisplayName = "É possível Realizar o PostBadRequest.")]
        public async Task PostBadRequest()
        {
            var serviceMock = new Mock<ILancamentoService>();

            serviceMock.Setup(m => m.Post(It.IsAny<LancamentoDtoCreate>())).ReturnsAsync(
                 new LancamentoDtoCreateResult
                 {
                     Id = Guid.NewGuid(),
                     ContaId = Guid.NewGuid(),
                     Description = "Crédito",
                     Value = 100,
                     CreateAt = DateTime.Now
                 }
            );

            _controller = new LancamentosController(serviceMock.Object);
            _controller.ModelState.AddModelError("ContaId", "É um Campo Obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var lancamentoDtoCreate = new LancamentoDtoCreate
            {
                ContaId = Guid.NewGuid(),
                Description = "Crédito",
                Value = 100
            };

            var result = await _controller.Post(lancamentoDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
