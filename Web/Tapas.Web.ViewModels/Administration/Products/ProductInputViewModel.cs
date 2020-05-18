﻿namespace Tapas.Web.ViewModels.Administration.Products
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
            this.Sizes = new InputProductSizeModel[3];
            this.AvailablePackages = new List<PackageViewModel>();
            this.Seed();
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

        public List<PackageViewModel> AvailablePackages { get; set; }

        public InputProductSizeModel[] Sizes { get; set; }

        protected void Seed()
        {
            this.Sizes[0] = new InputProductSizeModel();
            this.Sizes[1] = new InputProductSizeModel();
            this.Sizes[2] = new InputProductSizeModel();
        }
    }
}
