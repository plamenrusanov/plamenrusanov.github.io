namespace Tapas.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Packages;
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class SizesService : ISizesService
    {
        private readonly IDeletableEntityRepository<MenuProduct> menuRepository;
        private readonly IDeletableEntityRepository<Package> packageRepository;
        private readonly IDeletableEntityRepository<ProductSize> sizeRepository;

        public SizesService(
            IDeletableEntityRepository<MenuProduct> menuRepository,
            IDeletableEntityRepository<Package> packageRepository,
            IDeletableEntityRepository<ProductSize> sizeRepository)
        {
            this.menuRepository = menuRepository;
            this.packageRepository = packageRepository;
            this.sizeRepository = sizeRepository;
        }

        public bool ExistById(int sizeId)
        {
            return this.sizeRepository.All().Any(x => x.Id == sizeId);
        }

        public ProductSizeViewModel GetDetailModel(int sizeId)
        {
            return this.sizeRepository.All()
                .Where(x => x.Id == sizeId)
                .Select(x => new ProductSizeViewModel()
                {
                    SizeId = x.Id,
                    SizeName = x.SizeName,
                    Price = x.Price,
                    Weight = x.Weight,
                    MaxProductsInPackage = x.MaxProductsInPackage,
                    PackagePrice = x.Package.Price,
                }).FirstOrDefault();
        }

        public List<EditProductSizeModel> GetSizesOfProduct(string productId)
        {
            var sizes = this.menuRepository
                .All()
                .Where(x => x.Id == productId)
                .SelectMany(x => x.Sizes)
                .ToList();
            var packages = this.packageRepository
                .All()
                .ToList();

            return sizes.Select(x => new EditProductSizeModel()
            {
                SizeId = x.Id,
                SizeName = x.SizeName,
                Price = x.Price,
                Weight = x.Weight,
                PackageId = x.PackageId,
                MaxProductsInPackage = x.MaxProductsInPackage,
                Packages = packages
                    .Select(p => new PackageViewModel()
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }).ToList(),
            }).ToList();
        }
    }
}
