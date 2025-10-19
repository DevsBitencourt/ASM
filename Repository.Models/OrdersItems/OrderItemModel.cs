namespace Repository.Models.OrdersItems
{
    public class OrderItemModel
    {
        public int IdOrder { get; set; }
        public int idProduct { get; set; }
        public int Amount { get; set; }
    }
}
