namespace Tapas.Web.ViewModels.Administration.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryInputViewModel
    {
        [Required]
        [StringLength(20, MinimumLength =3)]
        public string Name { get; set; }
    }
}
