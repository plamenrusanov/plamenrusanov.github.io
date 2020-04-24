namespace Tapas.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Packages;

    public class PackagesService : IPackagesService
    {
        private readonly IDeletableEntityRepository<Package> packageRepository;

        public PackagesService(IDeletableEntityRepository<Package> packageRepository)
        {
            this.packageRepository = packageRepository;
        }

        public async Task AddAsync(PackageInputModel model)
        {
            await this.packageRepository
               .AddAsync(new Package()
               {
                   Name = model.Name,
                   Price = model.Price,
               });
            await this.packageRepository.SaveChangesAsync();
        }

        public ICollection<PackageViewModel> All()
        {
            return this.packageRepository.All().Select(x => new PackageViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
            }).ToList();
        }

        public void Edit(PackageViewModel packageViewModel)
        {
            var package = this.packageRepository.All()
                .Where(x => x.Id == packageViewModel.Id)
                .FirstOrDefault();
            package.Name = packageViewModel.Name;
            package.Price = packageViewModel.Price;

            this.packageRepository.SaveChanges();
        }

        public bool ExistPackageById(int packageId)
        {
            return this.packageRepository.All().Any(x => x.Id == packageId);
        }

        public bool ExistPackageByName(string packageName)
        {
            return this.packageRepository.All().Any(x => x.Name == packageName);
        }

        public PackageViewModel GetPackageViewModelById(int packageId)
        {
            return this.packageRepository.All()
               .Where(x => x.Id == packageId)
               .Select(x => new PackageViewModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   Price = x.Price,
               })
               .FirstOrDefault();
        }

        public void Remove(int packageId)
        {
            var package = this.GetPackageById(packageId);

            this.packageRepository.Delete(package);
            this.packageRepository.SaveChanges();
        }

        private Package GetPackageById(int packageId)
           => this.packageRepository.All().FirstOrDefault(x => x.Id == packageId);
    }
}
