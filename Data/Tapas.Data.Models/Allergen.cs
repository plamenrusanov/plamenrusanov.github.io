namespace Tapas.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Allergen
    {
        public Allergen()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<AllergensProducts>();
        }

        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<AllergensProducts> Products { get; set; }
    }
}
