namespace Tapas.Web.Areas.Identity.Pages.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using Tapas.Data.Models;

    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<LogoutModel> logger;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger)
        {
            this.signInManager = signInManager;
            this.logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            await this.signInManager.SignOutAsync();
            this.logger.LogInformation($"{this.User.Identity.Name} logged out.");

            return this.RedirectPermanent("./../../Home/Index");
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await this.signInManager.SignOutAsync();
            this.logger.LogInformation($"{this.User.Identity.Name} logged out.");

            return this.RedirectPermanent("./../../Home/Index");
        }
    }
}
