namespace Tapas.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Tapas.Data.Common.Models;

    public class ShopingCart : BaseDeletableModel<string>
    {
        public ShopingCart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CartItems = new HashSet<ShopingCartItem>();
        }

        public string CustomerId { get; set; }

        public virtual ApplicationUser Customer { get; set; }

        public decimal TotalPrice => this.CartItems.Sum(x => x.Product.Price * x.Quantity);

        public string AddInfo { get; set; }

        public virtual ICollection<ShopingCartItem> CartItems { get; set; }
    }
}
