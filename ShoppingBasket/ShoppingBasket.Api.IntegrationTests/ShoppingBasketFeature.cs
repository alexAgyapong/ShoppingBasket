using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoppingBasket.Api.Model;

namespace ShoppingBasket.Api.IntegrationTests
{
    [TestFixture]
    public class ShoppingBasketFeature
    {
        private TestServer server;
        private IFixture fixture;
        private const string UserIdParameter = "{userId}";
        private const string PostUrl = "/api/baskets";
        // private const string PostUrl = "api/baskets/"+UserIdParameter+"/basket";
        private HttpClient client;

        [SetUp]
        public void InitialSetup()
        {
            server = CreateTestServer();
            client = server.CreateClient();
            fixture = new Fixture();
        }
        [Ignore("work on integration test later")]
        public async Task Create_a_shopping_basket_when_an_item_is_added_by_user()
        {
            var product = fixture.Create<Product>();
            var newProduct = new Product()
            {
                ProductId = fixture.Create<int>(),
                Name = fixture.Create<string>(),
                Category = fixture.Create<string>(),
                Stock = fixture.Create<int>(),
                UnitPrice = fixture.Create<decimal>()
            };

            var response = await client.PostAsync(PostUrl,
                new StringContent(JsonConvert.SerializeObject(newProduct), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
        }

        private async Task<HttpResponseMessage> AddToBasket(User user, Product product)
        {
            return await client.PostAsync(PostUrl,
                new StringContent(JsonConvert.SerializeObject(product),
                    Encoding.UTF8, "application/json"));
        }

        private string GetPostUrl(string userId)
        {
            return PostUrl.Replace(UserIdParameter, userId);
        }

        private static TestServer CreateTestServer()
        {
            var projectDir = System.IO.Directory.GetCurrentDirectory();
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(projectDir)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(projectDir)
                    //.AddJsonFile("appsettings.json")
                    .Build())
                .UseStartup<Startup>());
            return server;
        }
    }
}
