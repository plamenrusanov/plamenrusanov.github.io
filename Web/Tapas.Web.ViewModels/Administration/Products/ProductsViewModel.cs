namespace Tapas.Web.ViewModels.Administration.Products
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Administration.AllergensProducts;

    public class ProductsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string CategoryId { get; set; }

        public virtual ICollection<AllergensProductsViewModel> Allergens { get; set; }
    }
}
