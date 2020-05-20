namespace Tapas.Web.Hubs
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Extensions.Logging;
    using Tapas.Data.Models.Enums;
    using Tapas.Services.Data.Contracts;

    public class OrderHub : Hub
    {
        private readonly IOrdersService ordersService;
        private readonly IAlarm alarm;
        private readonly ILogger<OrderHub> logger;
        private readonly IHubContext<UserOrdersHub> hubUser;

        public OrderHub(IOrdersService ordersService, IAlarm alarm, ILogger<OrderHub> logger, IHubContext<UserOrdersHub> hubUser)
        {
            this.ordersService = ordersService;
            this.alarm = alarm;
            this.logger = logger;
            this.hubUser = hubUser;
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
            await this.Clients.Caller.SendAsync("OperatorFinished");
        }

        public async Task OperatorChangeStatus(string status, string order, string setTime)
        {
            if (string.IsNullOrEmpty(status) || string.IsNullOrEmpty(order))
            {
                await this.Clients.Caller.SendAsync("OperatorAlertMessage", "Липсват данни за статуса или номера на поръчката!");
                return;
            }

            try
            {
                var userId = await this.ordersService.ChangeStatusAsync(status, order, setTime);
                await this.Clients.Caller.SendAsync("OperatorStatusChanged", order, status);
                await this.hubUser.Clients.User(userId).SendAsync("UserStatusChanged", order, status);
                object statusResult = new object { };
                if (Enum.TryParse(typeof(OrderStatus), status, out statusResult))
                {
                    Action action = null;
                    switch ((OrderStatus)statusResult)
                    {
                        case OrderStatus.Processed: action = new Action(() => this.alarm.CreateAlarm(order, setTime)); break;
                        case OrderStatus.OnDelivery: action = new Action(() => this.alarm.RemoveAlarm(order)); break;
                        default:
                            break;
                    }

                    if (action != null)
                    {
                        var t = new Task(action);
                        t.Start();
                    }
                }
            }
            catch (System.Exception e)
            {
                await this.Clients.Caller.SendAsync("OperatorAlertMessage", e.Message);
            }
        }
    }
}
