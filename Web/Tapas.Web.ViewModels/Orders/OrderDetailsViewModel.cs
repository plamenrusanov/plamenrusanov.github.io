namespace Tapas.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;

    using Tapas.Data.Models.Enums;
    using Tapas.Web.ViewModels.ShopingCartItems;

    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }

        public string AddInfo { get; set; }

        public string UserUserName { get; set; }

        public string UserPhone { get; set; }

        public string DisplayAddress { get; set; }

        public string AddressInfo { get; set; }

        public string CreatedOn { get; set; }

        public string TimeForDelivery { get; set; }

        public decimal PackagesPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DeliveryFee { get; set; }

        public List<ShopingItemsViewModel> CartItems { get; set; }

        public OrderStatus Status { get; set; }
    }
}
