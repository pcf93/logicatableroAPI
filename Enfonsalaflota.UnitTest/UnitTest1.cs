using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;

namespace Enfonsalaflota.UnitTest
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
    {

        private const string mapGroup = "/test";
        private readonly WebApplicationFactory<Program> factory = new();

        [Fact]
        public async Task Get_V1_ShouldReturnsEmpty()
        {
            using var client = factory.CreateClient();
            //client.BaseAddress = new Uri("http://localhost:8080");
            client.DefaultRequestHeaders.Add("api-version", "1");

            var response = await client.GetStringAsync(mapGroup);
            response.ShouldBeEmpty();
        }
    }
}