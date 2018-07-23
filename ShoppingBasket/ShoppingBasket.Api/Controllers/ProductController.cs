using System;
using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.Api.Model;

namespace ShoppingBasket.Api.Controllers
{
    [Produces("application/json")]
    public class ProductController : Controller
    {
        // POST: api/Product
        [HttpPost]
        [Route("api/users/{userId}/product")]
        public IActionResult AddProduct([FromRoute]string userId,[FromBody] Product product)
        {
            throw new NotImplementedException();
        }
        
    }
}
