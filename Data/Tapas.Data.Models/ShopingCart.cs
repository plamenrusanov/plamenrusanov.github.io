namespace Tapas.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using Tapas.Data.Common.Models;

    public class ShopingCart : BaseDeletableModel<string>
    {
        public ShopingCart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CartItems = new HashSet<ShopingCartItem>();
        }

        public string ApplicationUserId { get; set; }

        [NotMapped]
        public decimal TotalPrice { get; set; }

        public string AddInfo { get; set; }

        public virtual ICollection<ShopingCartItem> CartItems { get; set; }
    }
}
