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

        public HomeIndexViewModel CategoryWhitProducts(string categoryId = null)
        {
            var model = new HomeIndexViewModel()
            {
                Categories = this.categoriesRepository
                .AllAsNoTracking()
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList(),
            };

            if (this.categoriesRepository.All().Any(x => x.Id == categoryId))
            {
                model.Products = this.menuRepository
                  .All()
                  .Where(x => x.CategoryId == categoryId)
                  .Select(x => new MenuProductViewModel()
                  {
                      Id = x.Id,
                      Name = x.Name,
                      ImageUrl = x.ImageUrl != null ? x.ImageUrl : GlobalConstants.DefaultProductImage,
                      IsOneSize = x.Sizes.Count == 1,
                      Sizes = x.Sizes.Select(s => s.SizeName).ToList(),
                      Weight = x.Sizes.Count == 1 ? x.Sizes.FirstOrDefault().Weight : default,
                      Price = x.Sizes.Count == 1 ? x.Sizes.FirstOrDefault().Price : default,
                  }).ToList();
                return model;
            }

            model.Products = this.menuRepository
                .All()
                .Select(x => new MenuProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl != null ? x.ImageUrl : GlobalConstants.DefaultProductImage,
                    IsOneSize = x.Sizes.Count == 1,
                    Sizes = x.Sizes.Select(s => s.SizeName).ToList(),
                    Weight = x.Sizes.Count == 1 ? x.Sizes.FirstOrDefault().Weight : default,
                    Price = x.Sizes.Count == 1 ? x.Sizes.FirstOrDefault().Price : default,
                }).ToList().Take(12);
            return model;
        }
    }
}
