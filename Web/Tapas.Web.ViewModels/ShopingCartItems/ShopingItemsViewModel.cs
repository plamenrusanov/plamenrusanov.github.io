namespace Tapas.Web.ViewModels.ShopingCartItems
{
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class ShopingItemsViewModel
    {
        public int Id { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public decimal ItemPrice => this.ProductPrice * this.Quantity;

        public string Description { get; set; }

        public int SizeId { get; set; }

        public ProductSizeViewModel Size { get; set; }
    }
}
