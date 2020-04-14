namespace Tapas.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Administration.Dashboard;

    public class DashboardController : AdministrationController
    {

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
