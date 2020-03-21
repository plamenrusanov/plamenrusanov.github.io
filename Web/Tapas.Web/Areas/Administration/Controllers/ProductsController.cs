namespace Tapas.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Web.ViewModels.Administration.Products;

    public class ProductsController : AdministrationController
    {
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(ProductInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            return this.Redirect("/");
        }
    }
}
