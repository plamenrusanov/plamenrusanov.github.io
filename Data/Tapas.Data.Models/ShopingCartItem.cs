namespace Tapas.Data.Models
{
    using Tapas.Data.Common.Models;

    public class ShopingCartItem : BaseDeletableModel<int>
    {
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string ShopingCartId { get; set; }

        public virtual ShopingCart Cart { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }
    }
}
