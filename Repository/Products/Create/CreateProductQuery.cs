namespace Repository.Products.Create
{
    internal class CreateProductQuery
    {
        public static string Create()
        {
            return @"INSERT INTO PRODUCTS(ID_PRODUCTS, NAME, AMOUNT, PRICE) VALUES(@id, @name, @amount, @price)";
        }
    }
}
