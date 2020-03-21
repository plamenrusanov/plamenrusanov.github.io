namespace Tapas.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Tapas.Services.Contracts;
    using Tapas.Web.ViewModels.Administration.Categories;

    public class CategoriesController : AdministrationController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
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

            if (this.categoriesService.IsCategoryExist(inputModel.Name))
            {
                this.ModelState.AddModelError(string.Empty, "Category already exist.");
                return this.View();
            }

            await this.categoriesService.AddAsync(inputModel.Name);

            return this.LocalRedirect("/Index");
        }
    }
}
