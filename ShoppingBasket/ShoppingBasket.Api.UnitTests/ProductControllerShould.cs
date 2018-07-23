using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ShoppingBasket.Api.Controllers;
using ShoppingBasket.Api.Model;
using ShoppingBasket.Api.Service;

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

            Assert.That(response.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
        }

        [Test]
        public void Delegate_adding_a_product_to_the_basket_to_the_service()
        {
            var productController = new ProductController();
            var product = fixture.Create<Product>();
            var basketServiceMock = new Mock<BasketService>();
            basketServiceMock.Setup(b => b.AddItem(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));

            var response = productController.AddProduct(fixture.Create<string>(), product) as StatusCodeResult;

            basketServiceMock.Verify(b => b.AddItem(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()),Times.Once());
            Assert.That(response.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
        }
    }
}
