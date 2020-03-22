namespace Tapas.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class CategoryWhitProductsViewModel
    {
        public CategoryWhitProductsViewModel()
        {
            this.Products = new HashSet<ProductsViewModel>();
        }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual IEnumerable<ProductsViewModel> Products { get; set; }
    }
}
