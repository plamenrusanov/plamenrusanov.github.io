namespace Tapas.Web.ViewModels.Administration.DeliveryTax
{
    public class DeliveryTaxInpitModel
    {
        [RequiredBg]
        public decimal Price { get; set; }

        [RequiredBg]
        public int MistralCode { get; set; }

        [RequiredBg]
        public string MistralName { get; set; }
    }
}
