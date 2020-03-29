namespace Tapas.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Tapas.Data.Common.Models;

    public class Allergen : BaseDeletableModel<string>
    {
        public Allergen()
            : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<AllergensProducts>();
        }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public virtual ICollection<AllergensProducts> Products { get; set; }
    }
}
