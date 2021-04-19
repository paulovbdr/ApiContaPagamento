using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Lancamento;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Lancamento
{
    public class LancamentoGet : LancamentoTestes
    {
        private ILancamentoService _service;
        private Mock<ILancamentoService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Get.")]
        public async Task QuandoExecutarGet()
        {
            _serviceMock = new Mock<ILancamentoService>();
            _serviceMock.Setup(m => m.Get(Id)).ReturnsAsync(lancamentoDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(Id);
            Assert.NotNull(result);
            Assert.True(result.Id == Id);
            Assert.Equal(ContaId, result.ContaId);
            Assert.Equal(Description, result.Description);

            _serviceMock = new Mock<ILancamentoService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((LancamentoDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Id);
            Assert.Null(_record);
        }
    }
}
