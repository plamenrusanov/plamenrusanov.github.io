namespace Tapas.Web.Hubs
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;
    using Tapas.Data.Models.Enums;
    using Tapas.Services.Data.Contracts;

    public class OrderHub : Hub
    {
        private readonly IOrdersService ordersService;
        private readonly IAlarm alarm;

        public OrderHub(IOrdersService ordersService, IAlarm alarm)
        {
            this.ordersService = ordersService;
            this.alarm = alarm;
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
                var result = await this.ordersService.ChangeStatusAsync(status, order, setTime);
                if (result)
                {
                    await this.Clients.Caller.SendAsync("OperatorStatusChanged", result, order, status);
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
            }
            catch (System.Exception e)
            {
                await this.Clients.Caller.SendAsync("OperatorAlertMessage", e.Message);
            }
        }
    }
}
