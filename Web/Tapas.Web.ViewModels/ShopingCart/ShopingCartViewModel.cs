namespace Tapas.Web.ViewModels.ShopingCart
{
    using System.Collections.Generic;
    using System.Linq;

    using Tapas.Web.ViewModels.ShopingCartItems;

    public class ShopingCartViewModel
    {
        public ShopingCartViewModel()
        {
            this.ShopingItems = new List<ShopingItemsViewModel>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public decimal TotalPrice => this.ShopingItems.Sum(x => x.ItemPrice);

        public List<ShopingItemsViewModel> ShopingItems { get; set; }
    }
}
