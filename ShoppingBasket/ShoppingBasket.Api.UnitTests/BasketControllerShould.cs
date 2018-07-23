using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ShoppingBasket.Api.Controllers;
using ShoppingBasket.Api.Model;
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

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
            basketServiceMock = new Mock<BasketService>();
            basketController = new BasketController(basketServiceMock.Object);
        }
        [Test]
        public void Create_a_basket_when_first_item_is_added()
        {
            basketServiceMock.Setup(b => b.AddItem(It.IsAny<string>(), It.IsAny<Product>()));
            var response = basketController
                           .AddToBasket(fixture.Create<string>(), fixture.Create<Product>()) as StatusCodeResult;
            
            basketServiceMock.Verify(b => b.AddItem(It.IsAny<string>(), It.IsAny<Product>()));
            Assert.That(response.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
        }
    }
}
