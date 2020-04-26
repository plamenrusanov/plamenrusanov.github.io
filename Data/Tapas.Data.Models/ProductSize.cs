namespace Tapas.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Tapas.Data.Common.Models;

    public class ProductSize : BaseDeletableModel<int>
    {
        public string SizeName { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        public int Weight { get; set; }

        public int MaxProductsInPackage { get; set; }

        public int? PackageId { get; set; }

        public virtual Package Package { get; set; }

        public string MenuProductId { get; set; }

        public virtual MenuProduct MenuProduct { get; set; }

        public string CareringProductId { get; set; }

        public virtual CateringProduct CateringProduct { get; set; }
    }
}
