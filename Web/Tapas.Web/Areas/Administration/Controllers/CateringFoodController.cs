namespace Tapas.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.CateringFood;

    public class CateringFoodController : AdministrationController
    {
        private readonly ICateringFoodService cateringFoodService;

        public CateringFoodController(ICateringFoodService cateringFoodService)
        {
            this.cateringFoodService = cateringFoodService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = this.cateringFoodService.GetAll();
            return this.View(model);
        }

        public IActionResult Create()
        {
            var model = this.cateringFoodService.CreateInputModel();
            return this.View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.cateringFoodService.AddCateringFoodAsync(model);
                return this.RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                return this.BadRequest();
            }
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        public IActionResult Delete()
        {
            return this.View();
        }
    }
}
