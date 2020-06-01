namespace Tapas.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Tapas.Common;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.CateringEquipment;

    public class CateringEquipmentController : AdministrationController
    {
        private readonly ICateringEquipmentService cateringEquipmentService;
        private readonly ILogger<CateringEquipmentController> logger;

        public CateringEquipmentController(
            ICateringEquipmentService cateringEquipmentService,
            ILogger<CateringEquipmentController> logger)
        {
            this.cateringEquipmentService = cateringEquipmentService;
            this.logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = this.cateringEquipmentService.GetAll();
            return this.View(model);
        }

        public IActionResult Create()
        {
            var model = this.cateringEquipmentService.CreateInputModel();
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
                await this.cateringEquipmentService.AddEquipmentAsync(model);
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
                var model = this.cateringEquipmentService.GetDetailsById(id);
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
                var model = this.cateringEquipmentService.GetEditModel(id);
                return this.View(model);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    this.logger.LogInformation(GlobalConstants.DefaultLogPattern, this.User.Identity.Name, e.InnerException.Message, e.InnerException.StackTrace);
                }

                this.logger.LogInformation(GlobalConstants.DefaultLogPattern, this.User.Identity.Name, e.Message, e.StackTrace);
                return this.BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Edit(EditModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                this.cateringEquipmentService.SetEditModel(model);
                return this.RedirectToAction("Index");
            }
            catch (Exception e)
            {
                this.logger.LogInformation(GlobalConstants.DefaultLogPattern, this.User.Identity.Name, e.Message, e.StackTrace);
                return this.BadRequest();
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.cateringEquipmentService.Delete(id);
                return this.RedirectToAction("Index");
            }
            catch (Exception e)
            {
                this.logger.LogInformation(GlobalConstants.DefaultLogPattern, this.User.Identity.Name, e.Message, e.StackTrace);
                return this.BadRequest();
            }
        }

        public IActionResult GetDeletedProducts()
        {
            try
            {
                var model = this.cateringEquipmentService.GetDeletedProducts();
                return this.View(model);
            }
            catch (Exception e)
            {
                this.logger.LogInformation(GlobalConstants.DefaultLogPattern, this.User.Identity.Name, e.Message, e.StackTrace);
                return this.NotFound();
            }
        }

        public async Task<IActionResult> Activate(string productId)
        {
            try
            {
                await this.cateringEquipmentService.ActivateAsync(productId);
                return this.RedirectToAction(actionName: "Details", routeValues: new { id = productId });
            }
            catch (Exception e)
            {
                this.logger.LogInformation(GlobalConstants.DefaultLogPattern, this.User.Identity.Name, e.Message, e.StackTrace);
                return this.NotFound();
            }
        }
    }
}
