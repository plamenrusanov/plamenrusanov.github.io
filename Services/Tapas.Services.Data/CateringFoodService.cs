namespace Tapas.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Contracts;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Allergens;
    using Tapas.Web.ViewModels.Administration.CateringFood;
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class CateringFoodService : ICateringFoodService
    {
        private readonly IDeletableEntityRepository<CateringProduct> cateringRepository;
        private readonly IAllergensService allergensService;
        private readonly IPackagesService packagesService;
        private readonly ICloudService cloudService;

        public CateringFoodService(
            IDeletableEntityRepository<CateringProduct> cateringRepository,
            IAllergensService allergensService,
            IPackagesService packagesService,
            ICloudService cloudService)
        {
            this.cateringRepository = cateringRepository;
            this.allergensService = allergensService;
            this.packagesService = packagesService;
            this.cloudService = cloudService;
        }

        // Post Administration/CateringFood/Create
        public async Task AddCateringFoodAsync(CreateModel model)
        {
            var cateringProduct = new CateringProduct()
            {
                Name = model.Name,
                Description = model.Description,
                NumberOfBits = model.NumberOfBits,
            };

            foreach (var item in model.Allergens)
            {
                cateringProduct.Allergens.Add(new AllergensProducts()
                {
                    ProductId = cateringProduct.Id,
                    AllergenId = item,
                });
            }

            foreach (var size in model.Sizes)
            {
                if (string.IsNullOrEmpty(size.SizeName))
                {
                    continue;
                }

                cateringProduct.Sizes.Add(
                  new ProductSize()
                  {
                      SizeName = size.SizeName,
                      PackageId = size.PackageId,
                      Price = size.Price,
                      Weight = size.Weight,
                      MaxProductsInPackage = size.MaxProductsInPackage,
                      MenuProductId = cateringProduct.Id,
                  });
            }

            if (model.Image != null)
            {
                cateringProduct.ImageUrl = await this.cloudService.UploadImageFromForm(model.Image);
            }

            await this.cateringRepository.AddAsync(cateringProduct);
            await this.cateringRepository.SaveChangesAsync();
        }

        // Administration/CateringFood/Create
        public CreateModel CreateInputModel()
        {
            return new CreateModel()
            {
                AvailableAllergens = this.allergensService.All().ToList(),
                AvailablePackages = this.packagesService.All().ToList(),
            };
        }

        // Administration/CateringFood/Index
        public List<IndexCateringFoodViewModel> GetAll()
        {
            return this.cateringRepository.All()
                .Select(x => new IndexCateringFoodViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    NumberOfBits = (int)x.NumberOfBits,
                    Allergens = x.Allergens
                        .Select(a => new DetailsAllergenViewModel()
                        {
                            Id = a.Allergen.Id,
                            Name = a.Allergen.Name,
                            ImageUrl = a.Allergen.ImageUrl,
                        }).ToList(),
                    Sizes = x.Sizes
                        .Select(s => new ProductSizeViewModel()
                        {
                            SizeId = s.Id,
                            SizeName = s.SizeName,
                            Price = s.Price,
                            Weight = s.Weight,
                            MaxProductsInPackage = s.MaxProductsInPackage,
                            PackagePrice = s.Package.Price,
                        }).ToList(),
                }).ToList();
        }
    }
}
