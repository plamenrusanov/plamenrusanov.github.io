namespace Tapas.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Tapas.Data.Models;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.Hubs;
    using Tapas.Web.ViewModels.Orders;

    [Authorize]
    public class OrdersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IOrdersService ordersService;
        private readonly IHubContext<OrderHub> hub;

        public OrdersController(
            UserManager<ApplicationUser> userManager,
            IOrdersService ordersService,
            IHubContext<OrderHub> hub)
        {
            this.userManager = userManager;
            this.ordersService = ordersService;
            this.hub = hub;
        }

        [Authorize(Roles = "Administrator, Operator")]
        public IActionResult Index()
        {
            var orders = this.ordersService.GetDailyOrders();
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
            if (this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var id = await this.ordersService.CreateAsync(user, model);
            await this.hub.Clients.All.SendAsync("NewOrder", id);
            return this.Redirect("/");
        }

        public IActionResult Details(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                return this.NotFound();
            }

            int id = default;

            bool result = int.TryParse(orderId, out id);
            if (!result || !this.ordersService.IsExists(id))
            {
                return this.NotFound();
            }

            var model = this.ordersService.GetDetailsById(id);

            return this.View(model);
        }

        public IActionResult All()
        {
            var model = this.ordersService.GetAll();
            return this.View(model);
        }

        public async Task<IActionResult> OrdersByUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return this.NotFound();
            }

            var user = await this.userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return this.NotFound();
            }

            var model = this.ordersService.GetOrdersByUserName(userName);
            return this.View(model);
        }

    }
}
