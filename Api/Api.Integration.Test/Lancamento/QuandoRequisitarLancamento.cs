using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Conta;
using Api.Domain.Dtos.Lancamento;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Lancamento
{
    public class QuandoRequisitarLancamento : BaseIntegration
    {
        [Fact]
        public async Task TestIntegrationLancamento()
        {

            var contaDtoCreate = new ContaDtoCreate()
            {
                Name = Faker.Name.FullName(),
                Description = "Conta Corrente",
                Status = true
            };

            //Post
            var response = await PostJsonAsync(contaDtoCreate, $"{hostApi}contas", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroContaPost = JsonConvert.DeserializeObject<ContaDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(contaDtoCreate.Name, registroContaPost.Name);
            Assert.Equal(contaDtoCreate.Description, registroContaPost.Description);
            Assert.Equal(contaDtoCreate.Status, registroContaPost.Status);
            Assert.True(registroContaPost.Id != default(Guid));

            var LancamentoDtoCreate = new LancamentoDtoCreate()
            {
                ContaId = registroContaPost.Id,
                Description = "Lancamento de crédito",
                Value = Faker.RandomNumber.Next(1, 1000)
            };

            //Post
            response = await PostJsonAsync(LancamentoDtoCreate, $"{hostApi}lancamentos", client);
            postResult = await response.Content.ReadAsStringAsync();
            var registroLancamentoPost = JsonConvert.DeserializeObject<LancamentoDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(LancamentoDtoCreate.ContaId, registroLancamentoPost.ContaId);
            Assert.Equal(LancamentoDtoCreate.Description, registroLancamentoPost.Description);
            Assert.Equal(LancamentoDtoCreate.Value, registroLancamentoPost.Value);
            Assert.True(registroLancamentoPost.Id != default(Guid));



            //GET Id
            response = await client.GetAsync($"{hostApi}lancamentos/{registroLancamentoPost.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<LancamentoDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroLancamentoPost.Id, registroSelecionado.Id);

        }
    }
}
