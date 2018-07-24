using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using NUnit.Framework;
using ShoppingBasket.Api.Model;
using ShoppingBasket.Api.Repository;

namespace ShoppingBasket.Api.IntegrationTests
{
    [TestFixture]
    public class BasketFeature
    {
        private IFixture fixture;
        private ProductRepository productRepository;
        private Basket basket;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
            productRepository = new ProductRepository();
            basket = new Basket();
        }
        [Test]
        public void Add_first_item_to_basket()
        {
            var product = fixture.Create<Product>();
            var product2 = fixture.Create<Product>();

            productRepository.Add(product);
            productRepository.Add(product2);
            basket.AddItem(product, 2);

            var item = basket.GetBasket().Where(p => p.Product.Equals(product));
            Assert.That(basket.GetBasket(), Is.EquivalentTo(item));
        }

        [Test]
        public void Return_2_when_two_items_are_added_to_basket()
        {
            var product = fixture.Create<Product>();
            var product2 = fixture.Create<Product>();

            productRepository.Add(product);
            productRepository.Add(product2);
            basket.AddItem(product, 2);
            basket.AddItem(product2, 2);

            Assert.That(basket.GetBasket().Count(), Is.EqualTo(2));
        }
    }
}
