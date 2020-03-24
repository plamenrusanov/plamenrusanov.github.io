namespace Tapas.Services.Data
{
    using System.Linq;
    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Contracts;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Products;

    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> productsRepo;
        private readonly ICloudService cloudService;
        private readonly IRepository<AllergensProducts> allergensProductsRepository;

        public ProductsService(
            IRepository<Product> productsRepo,
            ICloudService cloudService,
            IRepository<AllergensProducts> allergensProductsRepository)
        {
            this.productsRepo = productsRepo;
            this.cloudService = cloudService;
            this.allergensProductsRepository = allergensProductsRepository;
        }

        public async void AddAsync(ProductInputViewModel inputModel)
        {
            // var even = mapper.Map<Event>(model);
            var product = new Product()
            {
                Name = inputModel.Name,
                Price = inputModel.Price,
                CategoryId = inputModel.CategoryId,
                Allergens = inputModel.Allergens
                .Select(x => new AllergensProducts()
                {
                    AllergenId = x,
                }).ToList(),
            };

            if (inputModel.Image != null)
            {
                product.ImageUrl = this.cloudService.UploadImageToCloud(inputModel.Image).Result;
            }

            await this.productsRepo.AddEntityAsync(product);
        }
    }
}
