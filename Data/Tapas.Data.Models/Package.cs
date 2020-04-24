namespace Tapas.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using Tapas.Data.Common.Models;

    public class Package : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        public int MaxProducts { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
