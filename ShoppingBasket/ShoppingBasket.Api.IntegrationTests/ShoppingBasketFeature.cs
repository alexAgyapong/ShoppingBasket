using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Hosting;
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
        private const string PostUrl = "api/baskets/"+UserIdParameter+"/basket";
        public HttpClient Client { get; set; }

        [SetUp]
        public void InitialSetup()
        {
            server = CreateTestServer();
            Client = server.CreateClient();
            fixture = new Fixture();
        }
        [Test]
        public async Task Create_a_shopping_basket_when_an_item_is_added_by_user()
        {
            var product = fixture.Create<Product>();
            var user = fixture.Create<User>();

            var response = await AddToBasket(user, product);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        private async Task<HttpResponseMessage> AddToBasket(User user, Product product)
        {
            return await Client.PostAsync(GetPostUrl(user.UserId),
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
