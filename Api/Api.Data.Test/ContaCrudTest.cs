using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class ContaCrudTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public ContaCrudTest(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Conta")]
        [Trait("CRUD", "ContaEntity")]
        public async Task ContaCrud()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                ContaImplementation _repositorioConta = new ContaImplementation(context);

                ContaEntity _entityConta = new ContaEntity
                {
                    Name = Faker.Name.FullName(),
                    Description = "Conta Corrente",
                    Balance = 0,
                    Status = true
                };

                var _registroContaCriado = await _repositorioConta.InsertAsync(_entityConta);
                Assert.NotNull(_registroContaCriado);
                Assert.Equal(_entityConta.Name, _registroContaCriado.Name);
                Assert.Equal(_entityConta.Balance, _registroContaCriado.Balance);
                Assert.Equal(_entityConta.Status, _registroContaCriado.Status);

                _entityConta.Name = Faker.Name.First();
                var _registroAtualizado = await _repositorioConta.UpdateAsync(_entityConta);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entityConta.Name, _registroContaCriado.Name);
                Assert.Equal(_entityConta.Balance, _registroContaCriado.Balance);

                var _registroExiste = await _repositorioConta.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorioConta.SelectAsync(_registroContaCriado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroContaCriado.Description, _registroSelecionado.Description);
                Assert.Equal(_registroContaCriado.Id, _registroSelecionado.Id);

                var _todosRegistros = await _repositorioConta.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);

                var _removeu = await _repositorioConta.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

            }
        }
    }
}
