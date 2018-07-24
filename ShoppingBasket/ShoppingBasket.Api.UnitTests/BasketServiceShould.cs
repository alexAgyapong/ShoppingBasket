using System.Collections.Generic;
using AutoFixture;
using Moq;
using NUnit.Framework;
using ShoppingBasket.Api.Model;
using ShoppingBasket.Api.Repository;
using ShoppingBasket.Api.Service;

namespace ShoppingBasket.Api.UnitTests
{
    [TestFixture]
    public class BasketServiceShould
    {
        private IFixture fixture;
        private BasketService basketService;
        private Mock<Basket> basketMock;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
            basketMock = new Mock<Basket>();
            basketService = new BasketService(basketMock.Object);
        }

        [Test]
        public void Create_new_basket_when_item_is_added()
        {
            var userId = fixture.Create<string>();
            var product = fixture.Create<Product>();
            var product2 = fixture.Create<Product>();
            var product3 = fixture.Create<Product>();
            basketMock.Setup(b => b.AddItem(It.IsAny<Product>(), It.IsAny<int>()));

            basketService.AddItemToBasket(userId, product, 1);
            basketService.AddItemToBasket(userId, product2, 2);
            basketService.AddItemToBasket(userId, product3, 3);

            basketMock.Verify(b => b.AddItem(It.IsAny<Product>(), It.IsAny<int>()), Times.Exactly(3));
        }
    }
}