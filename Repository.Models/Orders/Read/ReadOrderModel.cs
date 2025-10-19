using Repository.Models.Orders.Enum;

namespace Repository.Models.Orders.Read
{
    public sealed class ReadOrderModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public EOrder Status { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public decimal Total
        {
            get
            {
                if (Items is not null)
                {
                    return Items.Select(i => i.Amount * i.ProductPrice).Sum();
                }
                else
                    return 0;
            }
        }
        public IList<ReadOrderItemModel>? Items { get; set; }

    }
}
