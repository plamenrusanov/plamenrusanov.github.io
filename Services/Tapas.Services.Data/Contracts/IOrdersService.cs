namespace Tapas.Services.Data.Contracts
{
    using Tapas.Data.Models;
    using Tapas.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        OrderInpitModel GetOrderViewModel(ApplicationUser user);
    }
}
