namespace Tapas.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Tapas.Data.Common.Models;

    public class Category : IDeletableEntity
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<Product>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
