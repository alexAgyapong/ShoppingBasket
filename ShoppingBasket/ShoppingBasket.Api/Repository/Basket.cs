using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Api.Model;

namespace ShoppingBasket.Api.Repository
{
    public class Basket
    {
        private readonly ICollection<BasketItem> basketItems;

        public Basket()
        {
            basketItems = new List<BasketItem>();
        }

        public virtual void AddItem(Product product, int quantity)
        {
            var basketItem = basketItems
                .FirstOrDefault(p => p.Product.ProductId.Equals(product.ProductId));
            if (basketItem == null)
            {
                basketItems.Add(new BasketItem()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                basketItem.Quantity += quantity;
            }
        }
        public virtual IEnumerable<BasketItem> GetBasket()
        {
            return basketItems;
        }
    }
}