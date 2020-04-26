namespace Tapas.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Tapas.Common;
    using Tapas.Data.Common;
    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Contracts;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Allergens;
    using Tapas.Web.ViewModels.Administration.AllergensProducts;
    using Tapas.Web.ViewModels.Administration.Products;

    public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<MenuProduct> productsRepo;
        private readonly ICloudService cloudService;
        private readonly IRepository<Allergen> allergensRepository;
        private readonly IRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Package> packageRepository;

        public ProductsService(
            IDeletableEntityRepository<MenuProduct> productsRepo,
            ICloudService cloudService,
            IRepository<Allergen> allergensRepository,
            IRepository<Category> categoriesRepository,
            IDeletableEntityRepository<Package> packageRepository)
        {
            this.productsRepo = productsRepo;
            this.cloudService = cloudService;
            this.allergensRepository = allergensRepository;
            this.categoriesRepository = categoriesRepository;
            this.packageRepository = packageRepository;
        }

        public async Task AddAsync(ProductInputViewModel model)
        {
            var product = new MenuProduct()
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Sizes = new List<ProductSize>()
                {
                },
            };

            foreach (var item in model.Allergens)
            {
                product.Allergens.Add(new AllergensProducts()
                {
                    ProductId = product.Id,
                    AllergenId = item,
                });
            }

            product.Sizes.Add(
                    new ProductSize()
                    {
                        SizeName = model.ProductSize.SizeName,
                        PackageId = model.ProductSize.PackageId,
                        Price = model.ProductSize.Price,
                        Weight = model.ProductSize.Weight,
                        MaxProductsInPackage = model.ProductSize.MaxProductsInPackage,
                        MenuProductId = product.Id,
                    });

            if (model.Image != null)
            {
                product.ImageUrl = await this.cloudService.UploadImageFromForm(model.Image);
            }

            await this.productsRepo.AddAsync(product);
            await this.productsRepo.SaveChangesAsync();
        }

        public MenuProductViewModel GetProductById(string productId)
        {
            return this.productsRepo.All()
                .Where(x => x.Id == productId)
                .Select(x => new MenuProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    //Price = x.Price,
                    //ImageUrl = x.ImageUrl != null ? x.ImageUrl : GlobalConstants.DefaultProductImage,
                    //CategoryId = x.CategoryId,
                    //Weight = x.Weight,
                    //Allergens = x.Allergens
                    //.Select(c => new AlergenDetailsViewModel()
                    //{
                    //    AllergenId = c.AllergenId,
                    //}).ToList(),
                }).FirstOrDefault();
        }

        public bool ExistProductById(string productId)
        {
            return this.productsRepo.AllWithDeleted().Any(x => x.Id == productId);
        }

        public DetailsProductViewModel GetDetailsProductById(string productId)
        {
            return this.productsRepo.All()
                .Where(x => x.Id == productId)
                .Select(x => new DetailsProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl != null ? x.ImageUrl : GlobalConstants.DefaultProductImage,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name,
                    Allergens = x.Allergens
                        .Select(c => new DetailsAllergenViewModel()
                        {
                            Id = c.AllergenId,
                            Name = c.Allergen.Name,
                            ImageUrl = c.Allergen.ImageUrl,
                        }).ToList(),
                })
                .FirstOrDefault();
        }

        public EditProductViewModel GetEditProductById(string productId)
        {
            return this.productsRepo.All()
                .Where(x => x.Id == productId)
                .Select(x => new EditProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    CategoryId = x.CategoryId,
                    Allergens = this.allergensRepository
                    .All()
                    .Select(c => new SelectListItem()
                    {
                        Value = c.Id,
                        Text = c.Name,
                        Selected = x.Allergens.Any(a => a.AllergenId == c.Id) ? true : false,
                    }).ToList(),
                    AvailableCategories = this.categoriesRepository
                        .All()
                        .Select(c => new SelectListItem()
                        {
                            Value = c.Id,
                            Text = c.Name,
                            Selected = x.CategoryId == c.Id ? true : false,
                        }).ToList(),

                })
                .FirstOrDefault();
        }

        public async Task EditProductAsync(EditProductViewModel model)
        {
            if (model.Image != null)
            {
                model.ImageUrl = await this.cloudService.UploadImageFromForm(model.Image);
            }

            var product = this.productsRepo.All()
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();
            product.Name = model.Name;
            product.ImageUrl = model.ImageUrl;
            product.CategoryId = model.CategoryId;

            foreach (var item in model.Allergens)
            {
                if (item.Selected)
                {
                    if (!product.Allergens.Any(x => x.AllergenId == item.Value))
                    {
                        product.Allergens
                            .Add(new AllergensProducts()
                            {
                                ProductId = product.Id,
                                AllergenId = item.Value,
                            });
                    }
                }
                else
                {
                    if (product.Allergens.Any(x => x.AllergenId == item.Value))
                    {
                        var allergenProduct = product.Allergens.FirstOrDefault(x => x.AllergenId == item.Value);
                        product.Allergens.Remove(allergenProduct);
                    }
                }
            }

            await this.productsRepo.SaveChangesAsync();
        }

        public DeleteProductViewModel GetDeleteProductById(string productId)
        {
            return this.productsRepo.All()
                .Where(x => x.Id == productId)
                .Select(x => new DeleteProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    CategoryName = x.Category.Name,
                }).FirstOrDefault();
        }

        public async Task DeleteProductAsync(string productId)
        {
            var product = this.productsRepo.All()
                .Where(x => x.Id == productId)
                .FirstOrDefault();
            this.productsRepo.Delete(product);
            await this.productsRepo.SaveChangesAsync();
        }

        public ICollection<DetailsProductViewModel> GetAllProducts(bool isDeleted)
        {
            return this.productsRepo.AllWithDeleted()
                .Where(x => x.IsDeleted == isDeleted)
                .Select(x => new DetailsProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryName = x.Category.Name,
                    //Price = x.Price,
                    IsDeleted = x.IsDeleted,
                })
                .OrderBy(x => x.Name)
                .ToList();
        }

        public void Activate(string productId)
        {
            var product = this.productsRepo.AllWithDeleted()
                .Where(x => x.Id == productId)
                .FirstOrDefault();
            product.IsDeleted = false;
            this.productsRepo.SaveChanges();
        }
    }
}
