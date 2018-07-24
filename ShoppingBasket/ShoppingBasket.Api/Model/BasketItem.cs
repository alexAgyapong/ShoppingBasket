namespace ShoppingBasket.Api.Model
{
    public class BasketItem
    {
        public int ItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        protected bool Equals(BasketItem other)
        {
            return ItemId == other.ItemId && Equals(Product, other.Product) && Quantity == other.Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BasketItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ItemId;
                hashCode = (hashCode * 397) ^ (Product != null ? Product.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Quantity;
                return hashCode;
            }
        }
    }
}