namespace Tapas.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Web.ViewModels.Home;

    public class HomeService : IHomeService
    {
        private readonly IRepository<Category> categoriesRepository;

        public HomeService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<CategoryWhitProductsViewModel> CategoryWhitProducts()
        {
            return this.categoriesRepository
                .AllAsNoTracking()
                .Select(x => new CategoryWhitProductsViewModel()
                {
                    CategoryName = x.Name,
                    CategoryId = x.Id,
                    Products = x.Products.Select(c => new ProductsViewModel() { }).ToList(),
                }).ToList();
        }
    }
}
