namespace Tapas.Web.ViewModels.Administration.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class EditProductModel
    {
        public EditProductModel()
        {
            this.Allergens = new List<SelectListItem>();
            this.AvailableCategories = new List<SelectListItem>();
            this.Sizes = new List<EditProductSizeModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public string CategoryId { get; set; }

        public List<SelectListItem> Allergens { get; set; }

        public List<SelectListItem> AvailableCategories { get; set; }

        public List<EditProductSizeModel> Sizes { get; set; }
    }
}
