namespace Tapas.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EquipmentForRent : Product
    {
        public EquipmentForRent()
            : base()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
    }
}
