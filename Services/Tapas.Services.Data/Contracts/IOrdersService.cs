namespace Tapas.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tapas.Data.Models;
    using Tapas.Data.Models.Enums;
    using Tapas.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        OrderInpitModel GetOrderInputModel(ApplicationUser user);

        ICollection<OrdersViewModel> GetDailyOrders();

        Task<int> CreateAsync(ApplicationUser user, OrderInpitModel model);

        OrderDetailsViewModel GetDetailsById(int id);

        bool IsExists(int id);

        Task<string> ChangeStatusAsync(string status, string orderId, string setTime, string deliveryFee);

        ICollection<OrderCollectionViewModel> GetAll();

        ICollection<OrdersViewModel> GetOrdersByUserName(string userName);

        ICollection<UserOrderViewModel> GetMyOrders(ApplicationUser user);

        UserOrderDetailsViewModel GetUserDetailsById(int id);
    }
}
