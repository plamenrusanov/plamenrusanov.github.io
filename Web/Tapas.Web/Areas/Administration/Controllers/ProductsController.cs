namespace Tapas.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Tapas.Services.Contracts;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Categories;
    using Tapas.Web.ViewModels.Administration.Products;

    public class ProductsController : AdministrationController
    {
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;
        private readonly IAllergensService allergensService;
        private readonly ICloudService cloudService;

        public ProductsController(
            IProductsService productsService,
            ICategoriesService categoriesService,
            IAllergensService allergensService,
            ICloudService cloudService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.allergensService = allergensService;
            this.cloudService = cloudService;
        }

        public IActionResult Add()
        {
            var model = new ProductInputViewModel()
            {
                AvailableCategories = this.categoriesService.All()
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList(),
                AvailableAllergens = this.allergensService.All().ToList(),
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Add([FromForm]ProductInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.productsService.AddAsync(inputModel);

            return this.Redirect("/");
        }
    }
}
