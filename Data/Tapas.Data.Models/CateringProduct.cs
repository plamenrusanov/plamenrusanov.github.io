namespace Tapas.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class CateringProduct : Product
    {
        public CateringProduct()
         : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Allergens = new HashSet<AllergensProducts>();
        }

        public int NumberOfBits { get; set; }

        public virtual ICollection<AllergensProducts> Allergens { get; set; }

        public int SizeId { get; set; }

        public virtual ProductSize Size { get; set; }
    }
}
