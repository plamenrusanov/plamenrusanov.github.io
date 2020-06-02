namespace Tapas.Web.ViewModels.Administration.CateringEquipment
{
    using System.ComponentModel;

    public class Details
    {
        public string Id { get; set; }

        [DisplayName("Име")]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}
