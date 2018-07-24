using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using NUnit.Framework;
using ShoppingBasket.Api.Model;
using ShoppingBasket.Api.Repository;
using ShoppingBasket.Api.Service;

namespace ShoppingBasket.Api.UnitTests
{
    [TestFixture]
    public class BasketShould
    {
        private IFixture fixture;
        private Basket basket;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
            basket = new Basket();
        }

        [Test]
        public void Add_item_to_basket()
        {
            var userId = fixture.Create<string>();
            var product = fixture.Create<Product>();
            var product2 = fixture.Create<Product>();
            var product3 = fixture.Create<Product>();

            basket.AddItem(product,1);
            basket.AddItem(product2,2);
            basket.AddItem(product3,1);

            var items = basket.GetBasket();
            Assert.That(items.Count(),Is.EqualTo(3));
        }
    }
}
