namespace Tapas.Web.ViewModels.Administration.Sizes
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Extras;

    public class ProductSizeViewModel
    {
        [RequiredBg]
        public int SizeId { get; set; }

        public string SizeName { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int MaxProductsInPackage { get; set; }

        public decimal PackagePrice { get; set; }

        public bool HasExtras { get; set; }

        public List<ExtraCartItemModel> Extras { get; set; }

        public decimal SubTotal => this.Price + this.PackagePrice;
    }
}
