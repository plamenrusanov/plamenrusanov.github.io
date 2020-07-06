namespace Tapas.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Tapas.Data.Common.Models;

    public class DeliveryTax : BaseDeletableModel<int>
    {
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        public int MistralCode { get; set; }

        public string MistralName { get; set; }
    }
}
