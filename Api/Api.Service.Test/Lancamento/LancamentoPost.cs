using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Lancamento
{
    public class LancamentoPost : LancamentoTestes
    {
        private ILancamentoService _service;
        private Mock<ILancamentoService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Create.")]
        public async Task QuandoExecutarGetPost()
        {
            _serviceMock = new Mock<ILancamentoService>();
            _serviceMock.Setup(m => m.Post(lancamentoDtoCreate)).ReturnsAsync(lancamentoDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(lancamentoDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(ContaId, result.ContaId);
            Assert.Equal(Value, result.Value);
        }
    }
}
