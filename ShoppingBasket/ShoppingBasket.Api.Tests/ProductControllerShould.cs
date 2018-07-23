using NUnit.Framework;
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ShoppingBasket.Api;

namespace ShoppingBasket.Api.UnitTests
{
    [TestFixture]
    public class ProductControllerShould
    {
        [Test]
        public void Add_product_to_basket()
        {
            var productController = new ProductController();
            var response = productController.AddProduct();
            Assert.That(response, Is.EqualTo(HttpStatusCode.Created));
        }

    }
}
