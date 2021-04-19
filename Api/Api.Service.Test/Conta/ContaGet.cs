using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Conta;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Conta
{
    public class ContaGet : ContaTestes
    {
        private IContaService _service;
        private Mock<IContaService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Get.")]
        public async Task QuandoExecutarGet()
        {
            _serviceMock = new Mock<IContaService>();
            _serviceMock.Setup(m => m.Get(Id)).ReturnsAsync(contaDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(Id);
            Assert.NotNull(result);
            Assert.True(result.Id == Id);
            Assert.Equal(Name, result.Name);
            Assert.Equal(Description, result.Description);

            _serviceMock = new Mock<IContaService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((ContaDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Id);
            Assert.Null(_record);
        }
    }
}
