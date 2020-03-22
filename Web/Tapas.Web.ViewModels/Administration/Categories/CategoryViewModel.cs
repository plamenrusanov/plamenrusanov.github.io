namespace Tapas.Web.ViewModels.Administration.Categories
{
    using Tapas.Data.Models;
    using Tapas.Services.Mapping;

    public class CategoryViewModel : IMapTo<Category>, IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
