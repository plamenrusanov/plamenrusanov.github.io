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
            this.Sizes = new List<InputProductSizeModel>();
            this.Seed();
        }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        public string Description { get; set; }

        [Required]
        public int NumberOfBits { get; set; }

        public ICollection<AllergenViewModel> AvailableAllergens { get; set; }

        public ICollection<string> Allergens { get; set; }

        public List<PackageViewModel> AvailablePackages { get; set; }

        public List<InputProductSizeModel> Sizes { get; set; }

        protected void Seed()
        {
            this.Sizes.Add(new InputProductSizeModel());
        }
    }
}
