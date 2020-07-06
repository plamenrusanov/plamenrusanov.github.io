namespace Tapas.Web.ViewModels.Administration.DeliveryTax
{
    public class DeliveryTaxViewModel
    {
        [RequiredBg]
        public int Id { get; set; }

        [RequiredBg]
        public decimal Price { get; set; }

        [RequiredBg]
        public int MistralCode { get; set; }

        [RequiredBg]
        public string MistralName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
