namespace Tapas.Web.Hubs
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;
    using Tapas.Services.Data.Contracts;

    public class UserOrdersHub : Hub
    {
        private readonly IOrdersService ordersService;

        public UserOrdersHub(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public async Task GetUpdate(int i)
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
            await this.Clients.Caller.SendAsync("UserFinished");
        }
    }
}
