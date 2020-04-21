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
            this.Packages = new HashSet<PackageViewModel>();
        }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        public string CategoryId { get; set; }

        public int PackageId { get; set; }

        public ICollection<PackageViewModel> Packages { get; set; }

        public ICollection<CategoryViewModel> AvailableCategories { get; set; }

        public ICollection<AllergenViewModel> AvailableAllergens { get; set; }

        public ICollection<string> Allergens { get; set; }
    }
}
