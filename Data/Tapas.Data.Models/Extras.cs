namespace Tapas.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Tapas.Data.Common.Models;

    public class Extras : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int Quantity { get; set; }
    }
}
