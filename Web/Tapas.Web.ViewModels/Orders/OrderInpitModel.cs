namespace Tapas.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Tapas.Web.ViewModels.Addreses;
    using Tapas.Web.ViewModels.ShopingCartItems;

    public class OrderInpitModel
    {
        public OrderInpitModel()
        {
            this.Addresses = new List<AddressViewModel>();
        }

        public string AddInfo { get; set; }

        public string ApplicationUserId { get; set; }

        [Required(ErrorMessage = "Полето Адрес е задължително!")]
        public string AddressId { get; set; }

        public decimal PackegesPrice { get; set; }

        public decimal DeliveryFee { get; set; }

        public bool TakeAway { get; set; }

        public decimal OrderPrice { get; set; }

        public DateTime DelayedDelivery { get; set; }

        public List<AddressViewModel> Addresses { get; set; }

        public List<ShopingItemsViewModel> CartItems { get; set; }
    }
}
