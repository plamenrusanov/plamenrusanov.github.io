namespace Tapas.Data.Models
{
    using System;

    using Tapas.Data.Common.Models;

    public class AllergensProducts : IDeletableEntity
    {
        public string AllergenId { get; set; }

        public virtual Allergen Allergen { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
