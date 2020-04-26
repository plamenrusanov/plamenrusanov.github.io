namespace Tapas.Web.ViewModels.Administration.Products
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Administration.AllergensProducts;
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class MenuProductViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public bool IsOneSize { get; set; }

        public int? Weight { get; set; }

        public decimal? Price { get; set; }

        public List<string> Sizes { get; set; }
    }
}
