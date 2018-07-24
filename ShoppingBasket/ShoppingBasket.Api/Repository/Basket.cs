using System.Collections.Generic;
using System.Linq;
using ShoppingBasket.Api.Model;

namespace ShoppingBasket.Api.Repository
{
    public class Basket
    {
        private readonly ICollection<BasketItem> basketItems = new List<BasketItem>();

        public virtual IEnumerable<Product> GetProducts()
        {
            throw new System.NotImplementedException();
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

    }

    public class BasketItem
    {
        public int ItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}