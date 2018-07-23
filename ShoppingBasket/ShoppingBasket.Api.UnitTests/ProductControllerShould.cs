using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Ploeh.AutoFixture;
using ShoppingBasket.Api.Controllers;
using ShoppingBasket.Api.Model;

namespace ShoppingBasket.Api.UnitTests
{
    [TestFixture]
    public class ProductControllerShould
    {
        private IFixture fixture;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture(); 
        }
        [Test]
        public void Return_created_when_a_product_is_successfully_added_to_basket()
        {
            var productController = new ProductController();
            var product = fixture.Create<Product>();

            var response = productController.AddProduct(fixture.Create<string>(), product) as StatusCodeResult;

            Assert.That(response.StatusCode,Is.EqualTo(StatusCodes.Status200OK));
        }
    }
}
