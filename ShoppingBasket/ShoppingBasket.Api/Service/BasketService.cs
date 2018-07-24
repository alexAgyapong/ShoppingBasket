using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual void AddItemToBasket(string userId, Product product, int quantity)
        {
            if (string.IsNullOrEmpty(userId) && product == null)
            {
                throw new InvalidOperationException();
            }
            basket.AddItem(product,quantity);
        }
    }

    
}