namespace Tapas.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tapas.Web.ViewModels.Administration.Packages;

    public interface IPackagesService
    {
        bool ExistPackageByName(string packageName);

        bool ExistPackageById(int packageId);

        Task AddAsync(PackageInputModel model);

        ICollection<PackageViewModel> All();

        PackageViewModel GetPackageViewModelById(int packageId);

        void Edit(PackageViewModel packageViewModel);

        void Remove(int packageId);
    }
}
