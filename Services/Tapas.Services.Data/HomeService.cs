namespace Tapas.Services.Data
{
    using System.Collections.Generic;
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
        private readonly IRepository<Category> categoriesRepository;
        private readonly IRepository<Product> productsRepository;

        public HomeService(IRepository<Category> categoriesRepository, IRepository<Product> productsRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.productsRepository = productsRepository;
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

            if (categoryId == null)
            {
                model.Products = this.productsRepository
                    .All()
                    .Select(x => new ProductViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ImageUrl = x.ImageUrl != null ? x.ImageUrl : GlobalConstants.DefaultProductImage,
                        Price = x.Price,
                        CategoryId = x.CategoryId,
                    }).ToList().Take(12);
                return model;
            }

            model.Products = this.productsRepository
                   .All()
                   .Where(x => x.CategoryId == categoryId)
                   .Select(x => new ProductViewModel()
                   {
                       Id = x.Id,
                       Name = x.Name,
                       ImageUrl = x.ImageUrl != null ? x.ImageUrl : GlobalConstants.DefaultProductImage,
                       Price = x.Price,
                       CategoryId = x.CategoryId,
                   }).ToList();
            return model;
        }
    }
}
