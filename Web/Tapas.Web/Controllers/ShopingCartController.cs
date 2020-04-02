namespace Tapas.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Data.Models;
    using Tapas.Services.Data.Contracts;

    [Authorize]
    public class ShopingCartController : Controller
    {
        private readonly IShopingCartService cartService;
        private readonly UserManager<ApplicationUser> userManager;

        public ShopingCartController(IShopingCartService cartService, UserManager<ApplicationUser> userManager)
        {
            this.cartService = cartService;
            this.userManager = userManager;
        }

        // GET: ShopingCart
        public async Task<ActionResult> Index()
        {
            if (this.User == null)
            {
                return this.RedirectToPage("/Account/Login");
            }

            var user = await this.userManager.GetUserAsync(this.User);
            if (user.ShopingCart == null)
            {
                await this.cartService.CreateShopingCartAsync(user.Id);
            }

            var products = this.cartService.GetShopingCart(user);
            return this.View(products);
        }

        // GET: ShopingCart/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }

        // GET: ShopingCart/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: ShopingCart/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ShopingCart/Edit/5
        public ActionResult Edit(int id)
        {
            return this.View();
        }

        // POST: ShopingCart/Edit/5
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

        // GET: ShopingCart/Delete/5
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        // POST: ShopingCart/Delete/5
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
