namespace Tapas.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var model = this.addresesService.GetMyAddreses(user);
            return this.View(model);
        }

        public async Task<ActionResult> GetAddressFromLocation(string latitude, string longitude)
        {
            if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
            {
                // TO DO
            }

            var model = await this.addresesService.GetAddressAsync(latitude, longitude);

            return this.View();
        }

        // GET: Addreses/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Addreses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressInputModel model)
        {
            try
            {
                // TODO: Add insert logic here
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
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
