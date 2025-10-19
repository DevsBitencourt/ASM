namespace Repository.Models.Orders.Read
{
    public class ReadOrderItemModel
    {
        public int Sequence { get; set; }
        public decimal Amount { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
