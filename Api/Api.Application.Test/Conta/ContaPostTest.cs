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
    public class ContaPostTest
    {
        private ContasController _controller;

        [Fact(DisplayName = "É possível Realizar o PostCreated.")]
        public async Task PostCreated()
        {
            var serviceMock = new Mock<IContaService>();

            serviceMock.Setup(m => m.Post(It.IsAny<ContaDtoCreate>())).ReturnsAsync(
                 new ContaDtoCreateResult
                 {
                     Id = Guid.NewGuid(),
                     Name = "PV Conta",
                     Description = "Conta Corrente",
                     Balance = 0,
                     Status = true,
                     CreateAt = DateTime.Now
                 }
            );

            _controller = new ContasController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var contaDtoCreate = new ContaDtoCreate
            {
                Name = "PV Conta",
                Description = "Conta Corrente",
                Status = true
            };

            var result = await _controller.Post(contaDtoCreate);
            Assert.True(result is CreatedResult);
        }

        [Fact(DisplayName = "É possível Realizar o PostBadRequest.")]
        public async Task PostBadRequest()
        {
            var serviceMock = new Mock<IContaService>();

            serviceMock.Setup(m => m.Post(It.IsAny<ContaDtoCreate>())).ReturnsAsync(
                 new ContaDtoCreateResult
                 {
                     Id = Guid.NewGuid(),
                     Name = "PV Conta",
                     Description = "Conta Corrente",
                     Balance = 0,
                     Status = true,
                     CreateAt = DateTime.Now
                 }
            );

            _controller = new ContasController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var contaDtoCreate = new ContaDtoCreate
            {
                Name = "PV Conta",
                Description = "Conta Corrente",
                Status = true
            };

            var result = await _controller.Post(contaDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
