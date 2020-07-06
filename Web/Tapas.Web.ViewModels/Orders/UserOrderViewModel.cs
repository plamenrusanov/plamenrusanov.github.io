namespace Tapas.Web.ViewModels.Orders
{
    public class UserOrderViewModel
    {
        public int OrderId { get; set; }

        public string Status { get; set; }

        public string CreatedOn { get; set; }

        public string ArriveTime { get; set; }

        public bool TakeAway { get; set; }
    }
}
