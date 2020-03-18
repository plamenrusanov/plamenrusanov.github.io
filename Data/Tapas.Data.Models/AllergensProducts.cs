namespace Tapas.Data.Models
{
    public class AllergensProducts
    {
        public string AllergenId { get; set; }

        public virtual Allergen Allergen { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
