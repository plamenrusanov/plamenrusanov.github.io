namespace Tapas.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Tapas.Common;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.CateringFood;

    public class CateringFoodController : AdministrationController
    {
        private readonly ICateringFoodService cateringFoodService;
        private readonly ILogger<CateringFoodController> logger;

        public CateringFoodController(
            ICateringFoodService cateringFoodService,
            ILogger<CateringFoodController> logger)
        {
            this.cateringFoodService = cateringFoodService;
            this.logger = logger;
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
            catch (Exception e)
            {
                this.logger.LogInformation(GlobalConstants.DefaultLogPattern, this.User.Identity.Name, e.Message, e.StackTrace);
                return this.BadRequest();
            }
        }

        [AllowAnonymous]
        public IActionResult Details(string id)
        {
            try
            {
                var model = this.cateringFoodService.GetDetailsById(id);
                return this.View(model);
            }
            catch (Exception e)
            {
                this.logger.LogInformation(GlobalConstants.DefaultLogPattern, this.User.Identity.Name, e.Message, e.StackTrace);
                return this.BadRequest();
            }
        }

        public IActionResult Edit(string id)
        {
            try
            {
                return this.View();
            }
            catch (Exception e)
            {
                this.logger.LogInformation(GlobalConstants.DefaultLogPattern, this.User.Identity.Name, e.Message, e.StackTrace);
                return this.BadRequest();
            }
        }

        public IActionResult Delete()
        {
            return this.View();
        }
    }
}
