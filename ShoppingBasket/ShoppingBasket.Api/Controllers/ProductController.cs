using System;
using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.Api.Model;
using Microsoft.AspNetCore.Http;
using ShoppingBasket.Api.Repository;
using ShoppingBasket.Api.Service;

namespace ShoppingBasket.Api.Controllers
{
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // POST: api/Product
        [HttpPost]
        [Route("api/products")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            try
            {
                productRepository.Add(product);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
        }

    }
}
