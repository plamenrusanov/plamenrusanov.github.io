namespace Tapas.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using Tapas.Data.Common.Models;

    public class ExtraItem : BaseDeletableModel<int>
    {
        public int ExtraId { get; set; }

        public virtual Extra Extra { get; set; }

        public int ShopingCartItemId { get; set; }

        public virtual ShopingCartItem ShopingCartItem { get; set; }

        public int Quantity { get; set; }
    }
}
