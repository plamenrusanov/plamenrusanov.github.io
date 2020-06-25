namespace Tapas.Web.ViewModels.Administration.CateringFood
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Tapas.Web.ViewModels.Administration.Packages;
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class EditCateringFoodModel
    {
        public EditCateringFoodModel()
        {
            this.Allergens = new List<SelectListItem>();
            this.AvailablePackages = new List<PackageViewModel>();
        }

        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Брой хапки")]
        public int NumberOfBits { get; set; }

        public List<SelectListItem> Allergens { get; set; }

        [Required]
        public EditProductSizeModel Size { get; set; }

        public List<PackageViewModel> AvailablePackages { get; set; }
    }
}
