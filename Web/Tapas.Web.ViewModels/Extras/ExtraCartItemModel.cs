namespace Tapas.Web.ViewModels.Extras
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ExtraCartItemModel
    {
        [RequiredBg]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Weight { get; set; }

        [RequiredBg]
        [Range(0, 5)]
        public int Quantity { get; set; }
    }
}
