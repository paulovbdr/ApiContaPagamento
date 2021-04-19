using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Conta;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Conta
{
    public class ContaGetAll : ContaTestes
    {
        private IContaService _service;
        private Mock<IContaService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GETAll.")]
        public async Task QuandoExecutarGetAll()
        {
            _serviceMock = new Mock<IContaService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaContaDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<ContaDto>();
            _serviceMock = new Mock<IContaService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
