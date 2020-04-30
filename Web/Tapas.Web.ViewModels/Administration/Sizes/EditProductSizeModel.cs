namespace Tapas.Web.ViewModels.Administration.Sizes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using Tapas.Web.ViewModels.Administration.Packages;

    public class EditProductSizeModel
    {
        public EditProductSizeModel()
        {
            this.Packages = new List<PackageViewModel>();
        }

        public int SizeId { get; set; }

        public string SizeName { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int MaxProductsInPackage { get; set; }

        public int? PackageId { get; set; }

        public List<PackageViewModel> Packages { get; set; }

    }
}
