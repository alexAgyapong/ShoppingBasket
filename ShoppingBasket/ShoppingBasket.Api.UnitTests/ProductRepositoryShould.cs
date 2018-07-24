using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using NUnit.Framework;
using ShoppingBasket.Api.Model;
using ShoppingBasket.Api.Repository;

namespace ShoppingBasket.Api.UnitTests
{
    [TestFixture]
    public class ProductRepositoryShould
    {
        private IFixture fixture;
        private ProductRepository productRepository;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
            productRepository = new ProductRepository();
        }
        [Test]
        public void Add_item_to_basket()
        {
            var product = fixture.Create<Product>();
            var product2 = fixture.Create<Product>();
            var product3 = fixture.Create<Product>();

            productRepository.Add(product);
            productRepository.Add(product2);
            productRepository.Add(product3);
            var products = productRepository.GetProducts();
            Assert.That(products.Count(), Is.EqualTo(3));
        }
    }
}
