namespace Tapas.Web.ViewModels.ShopingCart
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Tapas.Web.ViewModels.Extras;
    using Tapas.Web.ViewModels.ShopingCartItems;

    public class ShopingCartViewModel
    {
        public ShopingCartViewModel()
        {
            this.ShopingItems = new List<ShopingItemsViewModel>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public decimal PackegesPrice { get; set; }

        public decimal TotalPrice => this.ShopingItems.Sum(x => x.ItemPrice)
                                   + this.PackegesPrice;

        public List<ShopingItemsViewModel> ShopingItems { get; set; }
    }
}
