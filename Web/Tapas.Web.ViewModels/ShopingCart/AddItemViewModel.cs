namespace Tapas.Web.ViewModels.ShopingCart
{
    using Tapas.Web.ViewModels.Administration.Products;

    public class AddItemViewModel
    {
        public DetailsProductViewModel Product { get; set; }

        public ShopingCartViewModel ShopingCart { get; set; }

        public int Quantity { get; set; }
    }
}
