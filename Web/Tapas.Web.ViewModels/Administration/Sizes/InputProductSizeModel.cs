namespace Tapas.Web.ViewModels.Administration.Sizes
{
    using System.ComponentModel.DataAnnotations;

    public class InputProductSizeModel
    {
        public string SizeName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        [Range(1, 100)]
        public int MaxProductsInPackage => 1;
    }
}
