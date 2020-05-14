namespace Tapas.Web.Hubs
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using Tapas.Services.Data.Contracts;
    using Tapas.Web.ViewModels.Orders;

    [Authorize(Roles ="Administrator, Operator")]
    public class OrderHub : Hub
    {
        private readonly IOrdersService ordersService;

        public OrderHub(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public async Task GetUpdateForOrder()
        {
            bool haveUpdate = false;
            do
            {
                if (this.ordersService.IsThereNew())
                {
                    haveUpdate = true;
                    var order = this.ordersService.GetUpdate();
                    await this.Clients.Caller.SendAsync("ReceiveOrderUpdate", order);
                }
            }
            while (haveUpdate);
            await this.Clients.Caller.SendAsync("Finished");
        }

        public async Task ChangeStatus(string status, string order, string setTime)
        {
            if (string.IsNullOrEmpty(status) || string.IsNullOrEmpty(order))
            {
                await this.Clients.Caller.SendAsync("AlertMessage", "Липсват данни за статуса или номера на поръчката!");
                return;
            }

            try
            {
                var result = await this.ordersService.ChangeStatusAsync(status, order, setTime);
                await this.Clients.Caller.SendAsync("StatusChanged", result, order, status);
            }
            catch (System.Exception e)
            {
                await this.Clients.Caller.SendAsync("AlertMessage", e.Message);
            }
        }
    }
}
