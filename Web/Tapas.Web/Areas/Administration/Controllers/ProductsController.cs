namespace Tapas.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
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

        [AllowAnonymous]
        public IActionResult Index()
        {
            var homeIndexViewModel = this.productsService.CategoryWhitProducts();
            return this.View(homeIndexViewModel);
        }

        [AllowAnonymous]
        public IActionResult GetProductsByCategory(string categoryId)
        {
            var homeIndexViewModel = this.productsService.CategoryWhitProducts(categoryId);
            return this.View("Index", homeIndexViewModel);
        }

        public IActionResult Add()
        {
            var model = new ProductInputViewModel()
            {
                AvailableCategories = this.categoriesService.All().ToList(),
                AvailableAllergens = this.allergensService.All().ToList(),
                AvailablePackages = this.packagesService.All().ToList(),
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
            if (string.IsNullOrEmpty(productId))
            {
                return this.NotFound();
            }

            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound();
            }

            try
            {
                var viewModel = this.productsService.GetDetailsProductById(productId);
                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.NotFound();
            }

        }

        public IActionResult Edit(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return this.NotFound();
            }

            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound();
            }

            try
            {
                var viewModel = this.productsService.GetEditProductById(productId);
                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditProductModel model)
        {
            // todo

            //if (!this.ModelState.IsValid)
            //{
            //    model.AvailableCategories = this.categoriesService
            //        .All()
            //        .Select(x => new SelectListItem()
            //        {
            //            Text = x.Name,
            //            Value = x.Id,
            //            Selected = x.Id == model.CategoryId ? true : false,
            //        })
            //        .ToList();
            //    model.AvailablePackages = this.packagesService.All().ToList();
            //    return this.View(model);
            //}

            try
            {
                await this.productsService.EditProductAsync(model);
                return this.RedirectToAction("GetProducts", false);
            }
            catch (ArgumentException ae)
            {
                model.AvailableCategories = this.categoriesService
                    .All()
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id,
                        Selected = x.Id == model.CategoryId ? true : false,
                    })
                    .ToList();
                model.AvailablePackages = this.packagesService.All().ToList();
                return this.View(model);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        public IActionResult Delete(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return this.NotFound();
            }

            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound();
            }

            try
            {
                var viewModel = this.productsService.GetDeleteProductById(productId);
                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }

        }

        public async Task<IActionResult> OnDelete(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return this.NotFound();
            }

            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound();
            }

            try
            {
                await this.productsService.DeleteProductAsync(productId);
                return this.RedirectToAction("GetProducts", false);
            }
            catch (Exception)
            {
                return this.RedirectToAction("GetProducts", true);
            }
        }

        public IActionResult GetProducts(bool isDeleted = false)
        {
            this.ViewData["Title"] = isDeleted ? Inactive : Active;
            this.ViewData["IsDeleted"] = isDeleted;
            try
            {
                var model = this.productsService.GetAllProducts(isDeleted);
                return this.View(model);
            }
            catch (Exception)
            {
                return this.NotFound();
            }

        }

        public IActionResult Activate(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return this.NotFound();
            }

            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound();
            }

            try
            {
                this.productsService.Activate(productId);

                return this.RedirectToAction("GetProducts", false);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }
    }
}
