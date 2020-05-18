namespace Tapas.Web.ViewModels.Administration.Products
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Administration.Categories;

    public class ProductsIndexViewModel
    {
        public virtual IEnumerable<MenuProductViewModel> Products { get; set; }

        public virtual IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
