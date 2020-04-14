namespace Tapas.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Tapas.Common;
    using Tapas.Data.Models;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Orders;

    [Authorize]
    public class OrdersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IOrdersService ordersService;

        public OrdersController(
            UserManager<ApplicationUser> userManager,
            IOrdersService ordersService)
        {
            this.userManager = userManager;
            this.ordersService = ordersService;
        }

        [Authorize(Roles = "Administrator, Operator")]
        public IActionResult Index()
        {
            var orders = this.ordersService.GetLast50();
            return this.View(orders);
        }

        public async Task<IActionResult> Create()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var model = this.ordersService.GetOrderInputModel(user);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderInpitModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.ordersService.CreateAsync(user, model);
            return this.Redirect("/");
        }

        public IActionResult Details(int id)
        {
            if (!this.ordersService.IsExists(id))
            {
                return this.NotFound($"Няма поръчка с номер {id}");
            }

            var model = this.ordersService.GetDetailsById(id);
            return this.View("Index", model);
        }
    }
}
