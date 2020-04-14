namespace Tapas.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Tapas.Data.Models;
    using Tapas.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        bool IsThereNew();

        OrderInpitModel GetOrderInputModel(ApplicationUser user);

        OrderDetailsViewModel GetLast50();

        Task CreateAsync(ApplicationUser user, OrderInpitModel model);

        OrderDetailsViewModel GetDetailsById(int id);

        bool IsExists(int id);
    }
}
