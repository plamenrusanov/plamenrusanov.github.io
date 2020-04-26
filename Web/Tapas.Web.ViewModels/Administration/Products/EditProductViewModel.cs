namespace Tapas.Web.ViewModels.Administration.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class EditProductViewModel
    {
        public EditProductViewModel()
        {
            this.Allergens = new List<SelectListItem>();
            this.AvailableCategories = new List<SelectListItem>();
            this.Sizes = new List<ProductSizeViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public string CategoryId { get; set; }

        public List<SelectListItem> Allergens { get; set; }

        public List<SelectListItem> AvailableCategories { get; set; }

        public List<ProductSizeViewModel> Sizes { get; set; }
    }
}
