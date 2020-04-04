namespace Tapas.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Data.Models;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.ShopingCart;

    [Authorize]
    public class ShopingCartController : Controller
    {
        private const string RefererHeader = "Referer";
        private const string LoginPageRoute = "/Account/Login";
        private const string IndexRoute = "/";
        private readonly IShopingCartService cartService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductsService productsService;

        public ShopingCartController(
            IShopingCartService cartService,
            UserManager<ApplicationUser> userManager,
            IProductsService productsService)
        {
            this.cartService = cartService;
            this.userManager = userManager;
            this.productsService = productsService;
        }

        // GET: ShopingCart
        public async Task<ActionResult> Index()
        {
            if (this.User == null)
            {
                return this.RedirectToPage(LoginPageRoute);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            if (user.ShopingCart == null)
            {
                await this.cartService.CreateShopingCartAsync(user.Id);
            }

            var cart = this.cartService.GetShopingCart(user);
            return this.View(cart);
        }

        // GET: ShopingCart/AddItem/string
        public async Task<ActionResult> AddItem(string productId)
        {
            if (this.User == null)
            {
                return this.RedirectToPage(LoginPageRoute);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            if (user.ShopingCart == null)
            {
                await this.cartService.CreateShopingCartAsync(user.Id);
            }

            if (!this.productsService.ExistProductById(productId))
            {
                return this.NotFound(productId);
            }

            var model = this.cartService.GetShopingModel(user, productId);

            return this.View(model);
        }

        // POST: ShopingCart/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem([FromForm]AddItemViewModel model)
        {
            try
            {
                this.cartService.AddItem(model);
                return this.Redirect(IndexRoute);
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

        public ActionResult DeleteProductItem(int itemId, string shopingCartId)
        {
            this.cartService.DeleteItem(itemId, shopingCartId);
            if (this.Request.Headers.ContainsKey(RefererHeader))
            {
                var refererValue = default(Microsoft.Extensions.Primitives.StringValues);
                bool result = this.Request.Headers.TryGetValue(RefererHeader, out refererValue);
                if (result)
                {
                    var uri = new Uri(refererValue);
                    return this.LocalRedirect(uri.PathAndQuery);
                }
            }

            return this.RedirectToAction(nameof(this.Index));
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
