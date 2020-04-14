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
            this.Addresses = new List<AddressViewModel>();
        }

        public string AddInfo { get; set; }

        public string ApplicationUserId { get; set; }

        public string AddressId { get; set; }

        public decimal? OrderPrice => this.CartItems?.Sum(x => x.ProductPrice * x.Quantity);

        public List<AddressViewModel> Addresses { get; set; }

        public List<ShopingItemsViewModel> CartItems { get; set; }
    }
}
