using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.Conta;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Conta
{
    public class QuandoRequisitarConta : BaseIntegration
    {
        [Fact]
        public async Task TestIntegrationConta()
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

            //Get All
            response = await client.GetAsync($"{hostApi}contas");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<ContaDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.True(listaFromJson.Where(r => r.Id == registroContaPost.Id).Count() == 1);

            var contaDtoUpdate = new ContaDtoUpdate()
            {
                Id = registroContaPost.Id,
                Name = Faker.Name.FullName(),
                Description = "Conta Corrente",
                Status = true
            };

            //PUT
            var stringContent = new StringContent(JsonConvert.SerializeObject(contaDtoUpdate),
                                    Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}contas", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<ContaDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(contaDtoUpdate.Name, registroAtualizado.Name);

            //GET Id
            response = await client.GetAsync($"{hostApi}contas/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<ContaDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(contaDtoUpdate.Id, registroSelecionado.Id);

            //DELETE
            response = await client.DeleteAsync($"{hostApi}contas/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GET ID depois do DELETE
            response = await client.GetAsync($"{hostApi}contas/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
