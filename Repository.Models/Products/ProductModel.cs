namespace Repository.Models.Products
{
    public sealed class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
    }
}
