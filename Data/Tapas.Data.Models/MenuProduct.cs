namespace Tapas.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class MenuProduct : Product
    {
        public MenuProduct()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Allergens = new List<AllergensProducts>();
            this.Sizes = new List<ProductSize>();
        }

        public bool HasExtras { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<AllergensProducts> Allergens { get; set; }

        public virtual ICollection<ProductSize> Sizes { get; set; }
    }
}
