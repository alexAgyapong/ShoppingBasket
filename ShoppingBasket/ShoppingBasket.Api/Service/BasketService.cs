using System;
using ShoppingBasket.Api.Model;
using ShoppingBasket.Api.Repository;

namespace ShoppingBasket.Api.Service
{
    public class BasketService
    {
        private readonly Basket basket;
        public BasketService(Basket basket)
        {
            this.basket = basket;
        }

        public virtual void AddItemToBasket(Product product, int quantity)
        {
            if (product == null)
            {
                throw new InvalidOperationException();
            }
            basket.AddItem(product,quantity);
        }
    }

    
}