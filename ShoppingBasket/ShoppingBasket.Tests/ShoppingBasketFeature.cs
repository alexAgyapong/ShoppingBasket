using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ShoppingBasket.Tests
{
    [TestFixture]
    public class ShoppingBasketFeature
    {
        [Test]
        public async Task Create_a_shopping_basket_for_each_user()
        {
            var response = await CreateBasket();

            Assert.That(response,Is.EqualTo(HttpStatusCode.Created));
        }

        private Task<HttpResponseMessage> CreateBasket()
        {
            throw new System.NotImplementedException();
        }
    }
}
