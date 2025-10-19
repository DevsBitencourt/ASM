namespace Repository.OrdersItems.Update
{
    internal class UpdateOrderItemQuery
    {
        public static string Command()
        {
            return $"UPDATE ORDERS_ITEMS SET AMOUNT = @amount WHERE IDFK_ORDERS = @id AND IDFK_PRODUCTS = @idProduct";
        }
    }
}
