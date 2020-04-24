namespace Tapas.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Common;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Packages;

    [Authorize(Roles = GlobalConstants.AdministratorName)]
    public class PackagesController : AdministrationController
    {
        private const string PackageExist = "Package already exist.";
        private readonly IPackagesService packagesService;

        public PackagesController(IPackagesService packagesService)
        {
            this.packagesService = packagesService;
        }

        public IActionResult Index()
        {
            if (this.User == null)
            {
                return this.RedirectToPage("/Account/Login");
            }

            var packages = this.packagesService.All();
            return this.View(packages);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PackageInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            if (this.packagesService.ExistPackageByName(inputModel.Name))
            {
                this.ModelState.AddModelError(string.Empty, PackageExist);
                return this.View();
            }

            await this.packagesService.AddAsync(inputModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Edit(int packageId)
        {
            var package = this.packagesService.GetPackageViewModelById(packageId);
            if (package == null)
            {
                return this.NotFound();
            }

            return this.View(package);
        }

        [HttpPost]
        public IActionResult Edit(PackageViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            this.packagesService.Edit(viewModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Details(int packageId)
        {
            if (!this.packagesService.ExistPackageById(packageId))
            {
                return this.NotFound();
            }

            var package = this.packagesService.GetPackageViewModelById(packageId);

            return this.View(package);
        }

        public IActionResult Delete(int packageId)
        {
            if (!this.packagesService.ExistPackageById(packageId))
            {
                return this.NotFound();
            }

            var package = this.packagesService.GetPackageViewModelById(packageId);

            return this.View(package);
        }

        public IActionResult OnDelete(int packageId)
        {
            if (!this.packagesService.ExistPackageById(packageId))
            {
                return this.NotFound();
            }

            this.packagesService.Remove(packageId);

            return this.RedirectToAction("Index");
        }
    }
}
