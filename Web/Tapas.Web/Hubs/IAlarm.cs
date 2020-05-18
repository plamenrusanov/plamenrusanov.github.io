namespace Tapas.Web.Hubs
{
    public interface IAlarm
    {
        void CreateAlarm(string order, string setTime);

        void RemoveAlarm(string order);
    }
}
