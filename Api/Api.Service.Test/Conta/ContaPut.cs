using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Conta
{
    public class ContaPut : ContaTestes
    {
        private IContaService _service;
        private Mock<IContaService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Update.")]
        public async Task QuandoExecutarGetPut()
        {
            _serviceMock = new Mock<IContaService>();
            _serviceMock.Setup(m => m.Post(contaDtoCreate)).ReturnsAsync(contaDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(contaDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Name, result.Name);
            Assert.Equal(Description, result.Description);

            _serviceMock = new Mock<IContaService>();
            _serviceMock.Setup(m => m.Put(contaDtoUpdate)).ReturnsAsync(contaDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(contaDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(Name, resultUpdate.Name);
            Assert.Equal(Description, resultUpdate.Description);

        }
    }
}
