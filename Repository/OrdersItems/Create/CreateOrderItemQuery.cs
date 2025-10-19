namespace Repository.OrdersItems.Create
{
    internal class CreateOrderItemQuery
    {
        public static string Command()
        {
            return $"INSERT INTO ORDERS_ITEMS(IDFK_ORDERS, IDFK_PRODUCTS, SEQUENCE, AMOUNT) VALUES (@id, @idProduct, @sequence, @amount)";
        }
    }
}
