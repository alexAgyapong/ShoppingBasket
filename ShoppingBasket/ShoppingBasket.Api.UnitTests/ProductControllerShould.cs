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
        private Mock<BasketService> basketServiceMock;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
            basketServiceMock = new Mock<BasketService>();
        }
       // [Test]
        public void Return_created_when_a_product_is_successfully_added_to_basket()
        {
            var productController = new ProductController(basketServiceMock.Object);
            var product = fixture.Create<Product>();

            var response = productController.AddProduct(fixture.Create<string>(), product,fixture.Create<int>()) as StatusCodeResult;

            Assert.That(response.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
        }

        //[Test]
        public void Delegate_adding_a_product_to_the_basket_to_the_service()
        {
            var productController = new ProductController(basketServiceMock.Object);
            var product = fixture.Create<Product>();
            basketServiceMock.Setup(b => b.AddItemToBasket(It.IsAny<string>(), It.IsAny<Product>(),It.IsAny<int>()));

            var response = productController.AddProduct(fixture.Create<string>(), product,fixture.Create<int>()) as StatusCodeResult;

            basketServiceMock.Verify(b => b.AddItemToBasket(It.IsAny<string>(), It.IsAny<Product>(), It.IsAny<int>()),Times.Once());
            Assert.That(response.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
        }
    }
}
