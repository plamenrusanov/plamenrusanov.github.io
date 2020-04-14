namespace Tapas.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Addreses;
    using Tapas.Web.ViewModels.ShopingCartItems;

    public class OrdersViewModel
    {
        public OrdersViewModel()
        {
            this.OrderStatus = new List<string>();
        }

        public int Id { get; set; }

        public string AddInfo { get; set; }

        public string ApplicationUserId { get; set; }

        public string AddressId { get; set; }

        public AddressViewModel Address { get; set; }

        public List<ShopingItemsViewModel> CartItems { get; set; }

        public string Status { get; set; }

        public List<string> OrderStatus { get; set; }
    }
}
