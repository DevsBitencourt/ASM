namespace Repository.Products.Update
{
    internal class UpdateProductQuery
    {
        public static string Command()
        {
            return @"UPDATE PRODUCTS SET NAME = @name, AMOUNT = @amount, PRICE = @price WHERE ID_PRODUCTS = @id";
        }

        public static string StockMovementCommand()
        {
            return @"UPDATE PRODUCTS SET AMOUNT = (AMOUNT + @amount) WHERE ID_PRODUCTS = @id";
        }
    }
}
