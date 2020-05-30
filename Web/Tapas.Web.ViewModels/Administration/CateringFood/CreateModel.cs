namespace Tapas.Web.ViewModels.Administration.CateringFood
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Tapas.Web.ViewModels.Administration.Allergens;
    using Tapas.Web.ViewModels.Administration.Packages;
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class CreateModel
    {
        public CreateModel()
        {
            this.Allergens = new List<string>();
            this.Size = new InputProductSizeModel();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int NumberOfBits { get; set; }

        public ICollection<AllergenViewModel> AvailableAllergens { get; set; }

        public ICollection<string> Allergens { get; set; }

        public List<PackageViewModel> AvailablePackages { get; set; }

        [Required]
        public InputProductSizeModel Size { get; set; }
    }
}
