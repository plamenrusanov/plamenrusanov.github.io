namespace Tapas.Web.ViewModels.Administration.Sizes
{
    using Tapas.Web.ViewModels.Administration.Packages;

    public class ProductSizeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int PackageId { get; set; }

        public virtual PackageViewModel Package { get; set; }
    }
}
