using Microsoft.AspNetCore.Mvc.Testing;
using Test_task;
using Test_task.Models;

namespace IntegrationTest
{
    public class IntegrationTest1 : IClassFixture<WebApplicationFactory<Program>>
    {


        private readonly WebApplicationFactory<Program> _factory;

        public IntegrationTest1(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CrudTest()
        {
            var client = _factory.CreateClient();
            await client.PostAsync("/User/addUser?userId=werwer", new StringContent(""));
            var response = await client.GetAsync("/User/getAll");
            var list=response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            Assert.True((list.Count()>0));
        }
    }
}