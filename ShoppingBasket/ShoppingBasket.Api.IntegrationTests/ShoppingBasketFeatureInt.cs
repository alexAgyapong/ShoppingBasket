using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;
using Microsoft.AspNetCore.TestHost;
namespace ShoppingBasket.Api.IntegrationTests
{
    [TestFixture]
    public class ShoppingBasketFeatureInt
    {
        private TestServer server;
        private const string PostUrl = "api/{userId}/basket";
        public HttpClient Client { get; set; }

        [SetUp]
        public void InitialSetup()
        {
            var builder = new WebHostBuilder().UseStartup<Startup>();
            server = new TestServer(builder);
            Client = server.CreateClient();
        }
        [Test]
        public async Task Create_a_shopping_basket_when_product_is_added()
        {
            var response = await Client.PostAsync(PostUrl, 
                new StringContent("", Encoding.UTF8, "application/json"));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}
