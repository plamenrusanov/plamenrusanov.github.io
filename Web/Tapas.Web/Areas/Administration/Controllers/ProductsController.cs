﻿namespace Tapas.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Categories;
    using Tapas.Web.ViewModels.Administration.Products;
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class ProductsController : AdministrationController
    {
        private const string Active = "Активни";
        private const string Inactive = "Неактивни";
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;
        private readonly IAllergensService allergensService;
        private readonly IPackagesService packagesService;

        public ProductsController(
            IProductsService productsService,
            ICategoriesService categoriesService,
            IAllergensService allergensService,
            IPackagesService packagesService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.allergensService = allergensService;
            this.packagesService = packagesService;
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
                ProductSize = new ProductSizeInputModel()
                {
                    AvailablePackages = this.packagesService.All().ToList(),
                },
            };
            return this.View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add([FromForm]ProductInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.productsService.AddAsync(inputModel);

            return this.Redirect("/");
        }

        public IActionResult Details(string productId)
        {
            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound();
            }

            var viewModel = this.productsService.GetDetailsProductById(productId);

            return this.View(viewModel);
        }

        public IActionResult Edit(string productId)
        {
            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound();
            }

            var viewModel = this.productsService.GetEditProductById(productId);
            return this.View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditProductViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.productsService.EditProductAsync(viewModel);

            return this.Redirect("/");
        }

        public IActionResult Delete(string productId)
        {
            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound();
            }

            var viewModel = this.productsService.GetDeleteProductById(productId);

            return this.View(viewModel);
        }

        public async Task<IActionResult> OnDelete(string productId)
        {
            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound();
            }

            await this.productsService.DeleteProductAsync(productId);

            return this.Redirect("/");
        }

        public IActionResult GetProducts(bool isDeleted)
        {
            this.ViewData["Title"] = isDeleted ? Inactive : Active;
            this.ViewData["IsDeleted"] = isDeleted;
            var model = this.productsService.GetAllProducts(isDeleted);
            return this.View(model);
        }

        public IActionResult Аctivate(string productId)
        {
            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound();
            }

            this.productsService.Activate(productId);
            return this.Redirect("/");
        }
    }
}
