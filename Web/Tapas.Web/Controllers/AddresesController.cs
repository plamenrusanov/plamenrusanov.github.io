namespace Tapas.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Common;
    using Tapas.Data.Models;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Addreses;

    [Authorize]
    public class AddresesController : Controller
    {
        private readonly IAddresesService addresesService;
        private readonly UserManager<ApplicationUser> userManager;

        public AddresesController(
            IAddresesService addresesService,
            UserManager<ApplicationUser> userManager)
        {
            this.addresesService = addresesService;
            this.userManager = userManager;
        }

        // GET: Addreses
        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var model = this.addresesService.GetMyAddreses(user);
            return this.View(model);
        }

        public async Task<AddressInputModel> GetAddressFromLocation(string latitude, string longitude)
        {
            if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
            {
                // TO DO
            }

            if (this.Request.Headers.ContainsKey(GlobalConstants.RefererHeader))
            {
                var refererValue = default(Microsoft.Extensions.Primitives.StringValues);
                bool result = this.Request.Headers.TryGetValue(GlobalConstants.RefererHeader, out refererValue);
                if (result)
                {
                    var uri = new Uri(refererValue);
                    this.ViewData.Add(GlobalConstants.RefererHeader, uri.PathAndQuery);
                }
            }

            var model = await this.addresesService.GetAddressAsync(latitude, longitude);

            return model;
        }

        // GET: Addreses/Create
        public IActionResult Create()
        {
            var model = new AddressInputModel();

            return this.View(model);
        }

        // POST: Addreses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddressInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.addresesService.CreateAddressAsync(user, model);

            return this.Redirect(GlobalConstants.IndexRoute);
        }

        // GET: Addreses/Edit/5
        public ActionResult AddCopy()
        {
            return this.View();
        }

        // POST: Addreses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }

        // GET: Addreses/Delete/5
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        // POST: Addreses/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }
    }
}
