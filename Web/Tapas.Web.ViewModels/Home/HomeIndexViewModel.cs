namespace Tapas.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Administration.Categories;
    using Tapas.Web.ViewModels.Administration.Products;

    public class ProductsIndexViewModel
    {

        public virtual IEnumerable<MenuProductViewModel> Products { get; set; }

        public virtual IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
