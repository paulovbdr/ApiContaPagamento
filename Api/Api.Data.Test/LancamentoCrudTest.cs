using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class LancamentoCrudTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public LancamentoCrudTest(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Lancamento")]
        [Trait("CRUD", "LancamentoEntity")]
        public async Task LancamentoCrud()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                LancamentoImplementation _repositorioLancamento = new LancamentoImplementation(context);
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


                LancamentoEntity _entityLancamento = new LancamentoEntity
                {
                    ContaId = _registroContaCriado.Id,
                    Description = "Crédito em conta",
                    Value = 100
                };

                var _registroCriado = await _repositorioLancamento.InsertLancamento(_entityLancamento, _entityConta);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entityLancamento.ContaId, _registroCriado.ContaId);
                Assert.Equal(_entityLancamento.Description, _registroCriado.Description);
                Assert.Equal(_entityLancamento.Value, _registroCriado.Value);

                var _registroSelecionado = await _repositorioLancamento.SelectAsync(_registroCriado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_registroCriado.Description, _registroSelecionado.Description);
                Assert.Equal(_registroCriado.Id, _registroSelecionado.Id);

                var _todosRegistros = await _repositorioLancamento.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);
            }
        }
    }
}
