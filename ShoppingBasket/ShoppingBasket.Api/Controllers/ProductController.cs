using System;
using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.Api.Model;
using Microsoft.AspNetCore.Http;
using ShoppingBasket.Api.Service;

namespace ShoppingBasket.Api.Controllers
{
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly BasketService basketService;

        public ProductController(BasketService basketService)
        {
            this.basketService = basketService;
        }

        public ProductController()
        {
            
        }

        // POST: api/Product
        [HttpPost]
        [Route("api/users/{userId}/product")]
        public IActionResult AddProduct([FromRoute]string userId, [FromBody] Product product)
        {
            try
            {
                basketService.AddItem(userId,product.ProductId,10);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
        }

    }
}
