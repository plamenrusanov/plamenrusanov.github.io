namespace Tapas.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Sizes;

    public class SizesController : AdministrationController
    {
        private readonly ISizesService sizesService;
        private readonly IProductsService productsService;

        public SizesController(ISizesService sizesService, IProductsService productsService)
        {
            this.sizesService = sizesService;
            this.productsService = productsService;
        }

        public IActionResult Add(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return this.NotFound();
            }

            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound();
            }

            var model = this.sizesService.GetSizesOfProduct(productId);
            return this.View(model);
        }

        public IActionResult Add(List<EditProductSizeModel> model)
        {
            return this.RedirectToAction("");
        }

        public IActionResult GetSizeModel(string sizeId)
        {
            if (string.IsNullOrEmpty(sizeId))
            {
                return this.NotFound();
            }

            int id = default;

            if (!int.TryParse(sizeId, out id))
            {
                return this.NotFound();
            }

            if (!this.sizesService.ExistById(id))
            {
                return this.NotFound();
            }

            var model = this.sizesService.GetDetailModel(id);

            return this.View(model);
        }
    }
}