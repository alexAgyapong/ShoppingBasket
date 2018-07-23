using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace ShoppingBasket.Api.IntegrationTests
{
    [TestFixture]
    public class ShoppingBasketFeature
    {
        private TestServer server;
        private const string PostUrl = "api/{userId}/basket";
        public HttpClient Client { get; set; }

        [SetUp]
        public void InitialSetup()
        {
            server = CreateTestServer();
            Client = server.CreateClient();
        }
        [Test]
        public async Task Create_a_shopping_basket_when_product_is_added()
        {
            var response = await Client.PostAsync(PostUrl, 
                new StringContent("", Encoding.UTF8, "application/json"));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
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
