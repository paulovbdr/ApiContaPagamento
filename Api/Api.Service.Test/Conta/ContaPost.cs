using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Conta
{
    public class ContaPost : ContaTestes
    {
        private IContaService _service;
        private Mock<IContaService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Create.")]
        public async Task QuandoExecutarGetPost()
        {
            _serviceMock = new Mock<IContaService>();
            _serviceMock.Setup(m => m.Post(contaDtoCreate)).ReturnsAsync(contaDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(contaDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Name, result.Name);
            Assert.Equal(Description, result.Description);
        }
    }
}
