namespace Tapas.Web.ViewModels.Administration.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Tapas.Web.ViewModels.Administration.Allergens;
    using Tapas.Web.ViewModels.Administration.Categories;
    using Tapas.Web.ViewModels.Administration.Packages;
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class ProductInputViewModel
    {
        public ProductInputViewModel()
        {
            this.AvailableAllergens = new HashSet<AllergenViewModel>();
            this.Allergens = new HashSet<string>();
            this.AvailableCategories = new HashSet<CategoryViewModel>();
            this.ProductSize = new ProductSizeInputModel();
        }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        public string Description { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public ICollection<CategoryViewModel> AvailableCategories { get; set; }

        public ICollection<AllergenViewModel> AvailableAllergens { get; set; }

        public ICollection<string> Allergens { get; set; }

        public ProductSizeInputModel ProductSize { get; set; }
    }
}
