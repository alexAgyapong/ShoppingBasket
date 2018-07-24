using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ShoppingBasket.Api.Controllers;
using ShoppingBasket.Api.Model;
using ShoppingBasket.Api.Repository;
using ShoppingBasket.Api.Service;

namespace ShoppingBasket.Api.UnitTests
{
    [TestFixture]
    public class ProductControllerShould
    {
        private IFixture fixture;
        private Mock<ProductRepository> productRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
            productRepositoryMock = new Mock<ProductRepository>();
        }
       [Test]
        public void Return_created_when_a_product_is_successfully_added()
        {
            var productController = new ProductController(productRepositoryMock.Object);
            var product = fixture.Create<Product>();

            var response = productController.AddProduct(product) as StatusCodeResult;

            Assert.That(response.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
        }

        [Test]
        public void Delegate_adding_a_product_to_the_repository()
        {
            var productController = new ProductController(productRepositoryMock.Object);
            var product = fixture.Create<Product>();
            productRepositoryMock.Setup(b => b.Add(It.IsAny<Product>()));

            var response = productController.AddProduct(product) as StatusCodeResult;

            productRepositoryMock.Verify(b => b.Add(It.IsAny<Product>()),Times.Once());
            Assert.That(response.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
        }
    }
}
