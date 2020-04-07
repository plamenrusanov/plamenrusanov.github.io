namespace Tapas.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Tapas.Data.Common.Models;
    using Tapas.Data.Models.Enums;

    public class Order : BaseModel<string>
    {
        public Order()
        {
            this.CartItems = new HashSet<ShopingCartItem>();
        }

        public string AddInfo { get; set; }

        public string ApplicationUserId { get; set; }

        public string AddressId { get; set; }

        public virtual DeliveryAddress Address { get; set; }

        public virtual ICollection<ShopingCartItem> CartItems { get; set; }

        public OrderStatus Status { get; set; }
    }
}
