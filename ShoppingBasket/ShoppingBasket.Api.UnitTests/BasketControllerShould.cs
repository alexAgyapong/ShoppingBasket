using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ShoppingBasket.Api.Controllers;
using ShoppingBasket.Api.Model;
using ShoppingBasket.Api.Repository;
using ShoppingBasket.Api.Service;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace ShoppingBasket.Api.UnitTests
{
    [TestFixture]
    public class BasketControllerShould
    {
        private IFixture fixture;
        private Mock<BasketService> basketServiceMock;
        private BasketController basketController;
        private Mock<Basket> basketMock;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
            basketMock = new Mock<Basket>();
            basketServiceMock = new Mock<BasketService>(basketMock.Object);
            basketController = new BasketController(basketServiceMock.Object);
        }
        [Test]
        public void Create_a_basket_when_first_item_is_added()
        {
            basketServiceMock.Setup(b => b.AddItemToBasket(It.IsAny<Product>(),It.IsAny<int>()));

            var response = basketController
                           .AddToBasket(fixture.Create<Product>(),
                           fixture.Create<int>()) as StatusCodeResult;

            basketServiceMock.Verify(b => b.AddItemToBasket( It.IsAny<Product>(), It.IsAny<int>()));
            Assert.That(response.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
        }
    }
}
