namespace Tapas.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    using Tapas.Data.Models.Enums;
    using Tapas.Web.ViewModels.Addreses;
    using Tapas.Web.ViewModels.ShopingCartItems;

    public class OrderDetailsViewModel
    {

        public int Id { get; set; }

        public string AddInfo { get; set; }

        public string UserUserName { get; set; }

        public string UserPhone { get; set; }

        public string DisplayAddress { get; set; }

        public string AddressInfo { get; set; }

        public string CreatedOn { get; set; }

        public List<ShopingItemsViewModel> CartItems { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderStatus> OrderStatus { get; set; }

        public List<OrdersViewModel> Orders { get; set; }
    }
}
