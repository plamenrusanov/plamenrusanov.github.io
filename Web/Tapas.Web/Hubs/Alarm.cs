namespace Tapas.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Microsoft.AspNetCore.SignalR;

    public class Alarm : IAlarm
    {
        private readonly IHubContext<OrderHub> hub;
        private Dictionary<string, DateTime> alarms;

        public Alarm(IHubContext<OrderHub> hub)
        {
            this.hub = hub;
            this.alarms = new Dictionary<string, DateTime>();
        }

        public void CreateAlarm(string order, string setTime)
        {
            double minutes;
            if (double.TryParse(setTime, out minutes))
            {
                var alarmTime = DateTime.UtcNow.AddMinutes(minutes - 10);
                this.alarms.Add(order, alarmTime);
            }
            else
            {
                throw new ArgumentException();
            }

            if (this.alarms.Count == 1)
            {
                this.SetAlarm();
            }
        }

        public void RemoveAlarm(string orderId)
        {
            if (this.alarms.ContainsKey(orderId))
            {
                this.alarms.Remove(orderId);
            }
        }

        private void SetAlarm()
        {
            while (this.alarms.Count > 0)
            {
                foreach (var alarm in this.alarms)
                {
                    if (alarm.Value <= DateTime.UtcNow)
                    {
                        int orderId;
                        if (int.TryParse(alarm.Key, out orderId))
                        {
                            try
                            {
                                 this.hub.Clients.All.SendAsync("OperatorSetAlarm", alarm.Key);
                            }
                            catch (Exception)
                            {
                            }
                        }

                        this.RemoveAlarm(alarm.Key);
                    }
                }

                Thread.Sleep(1000);
            }
        }
    }
}
