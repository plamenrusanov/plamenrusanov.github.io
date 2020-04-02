namespace Tapas.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Tapas.Data.Common.Models;

    public class DeliveryAddress : BaseDeletableModel<string>
    {
        public DeliveryAddress()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public string AddInfo { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
