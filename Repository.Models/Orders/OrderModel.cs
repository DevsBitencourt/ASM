using Repository.Models.Orders.Enum;

namespace Repository.Models.Orders
{
    public class OrderModel
    {
        public int IdOrder { get; set; }
        public int IdClient { get; set; }
        public EOrder Status { get; set; }
        public DateTime Date { get; set; }
    }
}
