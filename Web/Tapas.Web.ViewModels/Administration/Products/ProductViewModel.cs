namespace Tapas.Web.ViewModels.Administration.Products
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Administration.AllergensProducts;

    public class ProductViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string CategoryId { get; set; }

        public int Weight { get; set; }

        public virtual ICollection<AlergenDetailsViewModel> Allergens { get; set; }
    }
}
