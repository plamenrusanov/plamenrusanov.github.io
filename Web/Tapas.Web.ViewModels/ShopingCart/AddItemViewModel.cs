namespace Tapas.Web.ViewModels.ShopingCart
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Tapas.Web.ViewModels.Administration.Products;
    using Tapas.Web.ViewModels.Extras;

    public class AddItemViewModel
    {
        public DetailsProductAddItemVM Product { get; set; }

        [RequiredBg]
        public string ShopingCartId { get; set; }

        [RequiredBg]
        [Range(1, 10)]
        public int Quantity { get; set; }

        [MaxLength(150, ErrorMessage = "Максимум 150 символа!")]
        public string Description { get; set; }

        public List<ExtraCartItemModel> Extras { get; set; }
    }
}
