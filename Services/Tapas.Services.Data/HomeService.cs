namespace Tapas.Services.Data
{
    using System.Linq;

    using Tapas.Common;
    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Categories;
    using Tapas.Web.ViewModels.Administration.Products;
    using Tapas.Web.ViewModels.Home;

    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<MenuProduct> menuRepository;

        public HomeService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<MenuProduct> menuRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.menuRepository = menuRepository;
        }
    }
}
