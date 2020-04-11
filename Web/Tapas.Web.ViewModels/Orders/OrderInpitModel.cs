namespace Tapas.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tapas.Web.ViewModels.Addreses;
    using Tapas.Web.ViewModels.ShopingCartItems;

    public class OrderInpitModel
    {
        public OrderInpitModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CartItems = new List<ShopingItemsViewModel>();
            this.Addresses = new List<AddressViewModel>();
        }

        public string Id { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string AddInfo { get; set; }

        public string ApplicationUserId { get; set; }

        public string AddressId { get; set; }

        public decimal OrderPrice => this.CartItems.Sum(x => x.ItemPrice);

        public List<AddressViewModel> Addresses { get; set; }

        public List<ShopingItemsViewModel> CartItems { get; set; }

        public string Status { get; set; }
    }
}
