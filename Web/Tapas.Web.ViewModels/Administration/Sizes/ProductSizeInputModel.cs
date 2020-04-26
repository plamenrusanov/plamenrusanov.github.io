namespace Tapas.Web.ViewModels.Administration.Sizes
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Administration.Packages;

    public class ProductSizeInputModel
    {
        public ProductSizeInputModel()
        {
            this.AvailablePackages = new List<PackageViewModel>();
        }

        public string SizeName { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int PackageId { get; set; }

        public int MaxProductsInPackage { get; set; }

        public List<PackageViewModel> AvailablePackages { get; set; }
    }
}
