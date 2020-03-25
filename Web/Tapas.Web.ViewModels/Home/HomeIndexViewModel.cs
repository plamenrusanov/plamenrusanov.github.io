namespace Tapas.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Administration.Categories;
    using Tapas.Web.ViewModels.Administration.Products;

    public class HomeIndexViewModel
    {
        public HomeIndexViewModel()
        {
            this.Products = new HashSet<ProductsViewModel>();
            this.Categories = new HashSet<CategoryViewModel>();
        }

        public virtual IEnumerable<ProductsViewModel> Products { get; set; }

        public virtual IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
