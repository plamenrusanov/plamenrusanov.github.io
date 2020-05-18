namespace Tapas.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Tapas.Common;
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
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                var model = this.ordersService.GetOrderInputModel(user);
                if (model.OrderPrice < GlobalConstants.OrderPriceMin)
                {
                    return this.RedirectPermanent("/Administration/Products");
                }

                return this.View(model);
            }
            catch (System.Exception)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(OrderInpitModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Create");
            }

            try
            {
                var user = await this.userManager.GetUserAsync(this.User);
                var id = await this.ordersService.CreateAsync(user, model);
                await this.hub.Clients.All.SendAsync("OperatorNewOrder", id);
                return this.Redirect("/Orders/UserOrders");
            }
            catch (System.Exception)
            {
                return this.BadRequest();
            }
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

            try
            {
                var model = this.ordersService.GetDetailsById(id);
                return this.View(model);
            }
            catch (System.Exception)
            {
                return this.NotFound();
            }
        }

        public IActionResult All()
        {
            var model = this.ordersService.GetAll();
            return this.View(model);
        }

        public async Task<IActionResult> OrdersByUser(string userName = null)
        {
            if (string.IsNullOrEmpty(userName))
            {
                userName = this.User.Identity.Name;
            }

            var user = await this.userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return this.NotFound();
            }

            var model = this.ordersService.GetOrdersByUserName(userName);
            return this.View(model);
        }

        public async Task<IActionResult> UserOrders()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (user == null)
            {
                return this.Redirect(GlobalConstants.LoginPageRoute);
            }

            try
            {
                var model = this.ordersService.GetMyOrders(user);
                return this.View(model);
            }
            catch (Exception)
            {
                return this.NotFound();
            }
        }

        public IActionResult UserOrderDetails(string orderId)
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

            try
            {
                var model = this.ordersService.GetUserDetailsById(id);
                return this.View(model);
            }
            catch (System.Exception)
            {
                return this.NotFound();
            }
        }

        public async Task<bool> ChangeStatusAsync(string status, string orderId, string setTime)
        {
            try
            {
                await this.ordersService.ChangeStatusAsync(status, orderId, setTime);
                var userId = this.ordersService.GetUserIdByOrderId(orderId);
                await this.hub.Clients.User(userId).SendAsync("UserStatusChanged", true, orderId, status);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
