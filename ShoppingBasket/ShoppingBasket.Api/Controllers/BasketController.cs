using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.Api.Model;
using ShoppingBasket.Api.Service;

namespace ShoppingBasket.Api.Controllers
{
    [Produces("application/json")]
    public class BasketController : Controller
    {
        private readonly BasketService basketService;

        public BasketController(BasketService basketService)
        {
            this.basketService = basketService;
        }

        [HttpPost]
       // [Route("api/baskets/{userId}/basket")]
        [Route("/api/baskets")]
        public IActionResult AddToBasket([FromBody] Product product, int quantity)
        {
            try
            {
                basketService.AddItemToBasket(product, quantity);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}