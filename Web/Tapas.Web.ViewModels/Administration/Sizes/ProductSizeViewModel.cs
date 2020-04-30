namespace Tapas.Web.ViewModels.Administration.Sizes
{
    using Tapas.Web.ViewModels.Administration.Packages;

    public class ProductSizeViewModel
    {
        public int SizeId { get; set; }

        public string SizeName { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int MaxProductsInPackage { get; set; }

        public decimal PackagePrice { get; set; }

        public decimal SubTotal => this.Price + this.PackagePrice;
    }
}
