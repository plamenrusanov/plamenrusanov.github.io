namespace Tapas.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using Tapas.Data.Common.Models;

    public class Product : BaseDeletableModel<string>
    {
        public Product()
            : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Allergens = new HashSet<AllergensProducts>();
        }

        public string Name { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<AllergensProducts> Allergens { get; set; }
    }
}
