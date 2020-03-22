namespace Tapas.Web.ViewModels.Administration.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Tapas.Data.Models;
    using Tapas.Services.Mapping;

    public class CategoryInputViewModel : IMapTo<Category>
    {
        [Required]
        [StringLength(20, MinimumLength =3)]
        public string Name { get; set; }
    }
}
