namespace Tapas.Web.ViewModels.ShopingCart
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.ShopingCartItems;

    public class ShopingCartViewModel
    {
        public ShopingCartViewModel()
        {
            this.ShopingItems = new List<ShopingItemsViewModel>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public decimal TotalPrice { get; set; }

        public List<ShopingItemsViewModel> ShopingItems { get; set; }
    }
}
