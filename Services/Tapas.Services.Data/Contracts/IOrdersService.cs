namespace Tapas.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tapas.Data.Models;
    using Tapas.Data.Models.Enums;
    using Tapas.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        bool IsThereNew();

        OrderInpitModel GetOrderInputModel(ApplicationUser user);

        ICollection<OrdersViewModel> GetDailyOrders();

        Task<int> CreateAsync(ApplicationUser user, OrderInpitModel model);

        OrderDetailsViewModel GetDetailsById(int id);

        bool IsExists(int id);

        OrderDetailsViewModel GetUpdate();

        Task<bool> ChangeStatusAsync(string status, string orderId, string setTime);

        ICollection<OrderCollectionViewModel> GetAll();

        ICollection<OrdersViewModel> GetOrdersByUserName(string userName);

        ICollection<UserOrderViewModel> GetMyOrders(ApplicationUser user);

        OrderStatus CheckStatus(int orderId);

        UserOrderDetailsViewModel GetUserDetailsById(int id);

        string GetUserIdByOrderId(string orderId);
    }
}
