using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Conta
{
    public class ContaDelete : ContaTestes
    {
        private IContaService _service;
        private Mock<IContaService> _serviceMock;
        [Fact(DisplayName = "É Possivel executar o Método Delete.")]
        public async Task QuandoExecutarDelete()
        {
            _serviceMock = new Mock<IContaService>();
            _serviceMock.Setup(m => m.Delete(Id))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(Id);
            Assert.True(deletado);

            _serviceMock = new Mock<IContaService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }

    }
}
