using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.Api.Model;
using ShoppingBasket.Api.Service;

namespace ShoppingBasket.Api.Controllers
{
    [Produces("application/json")]
    public class BasketController : Controller
    {
        private BasketService basketService;

        public BasketController(BasketService basketService)
        {
            this.basketService = basketService;
        }

        [HttpPost]
        [Route("api/baskets/{userId}/basket")]
        public IActionResult AddToBasket([FromRoute] string userId, [FromBody] Product product)
        {
            try
            {
                basketService.AddItem(userId, product);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}