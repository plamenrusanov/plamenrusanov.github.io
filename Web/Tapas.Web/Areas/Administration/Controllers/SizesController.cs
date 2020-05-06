namespace Tapas.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Services.Data.Contracts;

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

        public IActionResult AddSizeModel(int index)
        {
            var model = this.sizesService.GetExtraSize(index);
            return this.View(model);
        }

        public IActionResult Remove(int id)
        {
            try
            {
                this.sizesService.Remove(id);
                return this.Ok();
            }
            catch (System.Exception)
            {
                return this.NotFound();
            }
        }
    }
}