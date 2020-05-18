namespace Tapas.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Common;
    using Tapas.Data.Models;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.ShopingCart;

    [Authorize]
    public class ShopingCartController : Controller
    {
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

        // GET
        public async Task<ActionResult> Index()
        {
            if (this.User == null)
            {
                return this.RedirectToPage(GlobalConstants.LoginPageRoute);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            if (user.ShopingCart == null)
            {
                await this.cartService.CreateShopingCartAsync(user.Id);
            }

            var cart = this.cartService.GetShopingCart(user);
            return this.View(cart);
        }

        // GET
        public async Task<ActionResult> AddItem(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return this.NotFound();
            }

            if (this.User == null)
            {
                return this.RedirectToPage(GlobalConstants.LoginPageRoute);
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

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem([FromForm]AddItemViewModel model)
        {
            if (this.User == null)
            {
                return this.RedirectToPage(GlobalConstants.LoginPageRoute);
            }

            try
            {
                this.cartService.AddItem(model);
                return this.RedirectToAction("Index");
            }
            catch (Exception)
            {
                return this.View();
            }
        }

        // GET
        public async Task<ActionResult> DeleteProductItem(int itemId, string shopingCartId)
        {
            if (this.User == null)
            {
                return this.RedirectToPage(GlobalConstants.LoginPageRoute);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            if (shopingCartId == null || user.ShopingCart.Id != shopingCartId)
            {
                shopingCartId = user.ShopingCart.Id;
            }

            if (!user.ShopingCart.CartItems.Any(x => x.Id == itemId))
            {
                return this.NotFound();
            }

            this.cartService.DeleteItem(itemId, shopingCartId);
            if (this.Request.Headers.ContainsKey(GlobalConstants.RefererHeader))
            {
                var refererValue = default(Microsoft.Extensions.Primitives.StringValues);
                bool result = this.Request.Headers.TryGetValue(GlobalConstants.RefererHeader, out refererValue);
                if (result)
                {
                    var uri = new Uri(refererValue);
                    return this.LocalRedirect(uri.PathAndQuery);
                }
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        public string GetDescription(int id)
        {
            var desc = this.cartService.GetDescription(id);
            if (desc is null)
            {
                desc = string.Empty;
            }

            return desc;
        }

        public string SetDescription(int id, string message)
        {
            this.cartService.SetDescription(id, message);
            return "Ok";
        }
    }
}
