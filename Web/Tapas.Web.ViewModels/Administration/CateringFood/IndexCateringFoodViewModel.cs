namespace Tapas.Web.ViewModels.Administration.CateringFood
{
    using System.Collections.Generic;

    using Tapas.Web.ViewModels.Administration.Allergens;
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class IndexCateringFoodViewModel
    {
        public IndexCateringFoodViewModel()
        {
            this.Allergens = new List<DetailsAllergenViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int NumberOfBits { get; set; }

        public List<DetailsAllergenViewModel> Allergens { get; set; }

        public ProductSizeViewModel Size { get; set; }
    }
}
