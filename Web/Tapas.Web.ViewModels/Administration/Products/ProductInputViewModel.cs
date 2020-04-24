namespace Tapas.Web.ViewModels.Administration.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Tapas.Web.ViewModels.Administration.Allergens;
    using Tapas.Web.ViewModels.Administration.Categories;
    using Tapas.Web.ViewModels.Administration.Packages;

    public class ProductInputViewModel
    {
        public ProductInputViewModel()
        {
            this.AvailableAllergens = new HashSet<AllergenViewModel>();
            this.Allergens = new HashSet<string>();
            this.AvailableCategories = new HashSet<CategoryViewModel>();
            this.AvailablePackages = new HashSet<PackageViewModel>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public string Description { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        [Range(1, 20)]
        public int MaxProductsInPackage { get; set; }

        [Required]
        public int PackageId { get; set; }

        public ICollection<CategoryViewModel> AvailableCategories { get; set; }

        public ICollection<AllergenViewModel> AvailableAllergens { get; set; }

        public ICollection<PackageViewModel> AvailablePackages { get; set; }

        public ICollection<string> Allergens { get; set; }
    }
}
