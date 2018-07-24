using System.Collections.Generic;
using ShoppingBasket.Api.Model;

namespace ShoppingBasket.Api.Repository
{
    public class ProductRepository
    {
        private List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>();
        }
        public virtual void Add(Product product)
        {
            products.Add(new Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                UnitPrice = product.UnitPrice,
                Category = product.Category,
                Stock = product.Stock
            });
        }

        public virtual IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}