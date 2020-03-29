namespace Tapas.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Common;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Categories;

    [Authorize(Roles = GlobalConstants.AdministratorName)]
    public class CategoriesController : AdministrationController
    {
        private const string CategoryExist = "Category already exist.";
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            if (this.User == null)
            {
                return this.RedirectToPage("/Account/Login");
            }

            var categories = this.categoriesService.All();
            return this.View(categories);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            if (this.categoriesService.ExistCategoryByName(inputModel.Name))
            {
                this.ModelState.AddModelError(string.Empty, CategoryExist);
                return this.View();
            }

            await this.categoriesService.AddAsync(inputModel.Name);

            return this.RedirectToAction("Index");
        }

        public IActionResult Edit(string categoryId)
        {
            var category = this.categoriesService.GetCategoryViewModelById(categoryId);
            if (category == null)
            {
                return this.NotFound();
            }

            return this.View(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            this.categoriesService.Edit(viewModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Details(string categoryId)
        {
            if (!this.categoriesService.ExistCategoryById(categoryId))
            {
                return this.NotFound();
            }

            var category = this.categoriesService.GetCategoryViewModelById(categoryId);

            return this.View(category);
        }

        public IActionResult Delete(string categoryId)
        {
            if (!this.categoriesService.ExistCategoryById(categoryId))
            {
                return this.NotFound();
            }

            var category = this.categoriesService.GetCategoryViewModelById(categoryId);

            return this.View(category);
        }

        public IActionResult OnDelete(string categoryId)
        {
            if (!this.categoriesService.ExistCategoryById(categoryId))
            {
                return this.NotFound();
            }

            this.categoriesService.Remove(categoryId);

            return this.RedirectToAction("Index");
        }
    }
}
