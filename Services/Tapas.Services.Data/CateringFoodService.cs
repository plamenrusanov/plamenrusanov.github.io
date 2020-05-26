namespace Tapas.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Rendering;
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

        // Administration/CateringFood/Details
        public DetailsCateringFoodViewModel GetDetailsById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException();
            }

            var product = this.cateringRepository
                .All()
                .Where(x => x.Id == id)
                .Select(x => new DetailsCateringFoodViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    NumberOfBits = x.NumberOfBits,
                    Size = x.Sizes.Select(s => new ProductSizeViewModel()
                    {
                        SizeId = s.Id,
                        SizeName = s.SizeName,
                        Price = s.Price,
                        Weight = s.Weight,
                        PackagePrice = s.Package.Price,
                        MaxProductsInPackage = s.MaxProductsInPackage,
                    }).FirstOrDefault(),
                    Allergens = x.Allergens.Select(a => new DetailsAllergenViewModel()
                    {
                        Id = a.AllergenId,
                        Name = a.Allergen.Name,
                        ImageUrl = a.Allergen.ImageUrl,
                    }).ToList(),
                }).FirstOrDefault();

            if (product is null)
            {
                throw new ArgumentException();
            }

            return product;
        }

        public EditCateringFoodModel GetEditModel(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException();
            }

            try
            {
                var product = this.cateringRepository
                    .All()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                if (product is null)
                {
                    throw new ArgumentNullException();
                }

                var model = new EditCateringFoodModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    ImageUrl = product.ImageUrl,
                    NumberOfBits = product.NumberOfBits,
                    Description = product.Description,
                    Size = product.Sizes.Select(s => new EditProductSizeModel()
                    {
                        SizeId = s.Id,
                        SizeName = s.SizeName,
                        Price = s.Price,
                        Weight = s.Weight,
                        PackageId = s.PackageId,
                        MaxProductsInPackage = s.MaxProductsInPackage,
                    }).FirstOrDefault(),
                    AvailablePackages = this.packagesService.All().ToList(),
                };

                model.Allergens = this.allergensService
                           .All()
                           .Select(c => new SelectListItem()
                           {
                               Value = c.Id,
                               Text = c.Name,
                               Selected = product.Allergens.Any(a => a.AllergenId == c.Id) ? true : false,
                           }).ToList();

                return model;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
