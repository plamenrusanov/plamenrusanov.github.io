namespace Tapas.Web.ViewModels.Administration.Products
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteProductViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Продукт")]
        public string Name { get; set; }

        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}
