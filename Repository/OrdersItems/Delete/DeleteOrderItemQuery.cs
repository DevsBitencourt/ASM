namespace Repository.OrdersItems.Delete
{
    internal class DeleteOrderItemQuery
    {
        public static string Command()
        {
            return "DELETE FROM ORDERS_ITEMS WHERE IDFK_ORDERS = @id AND IDFK_PRODUCTS = @idProduct";
        }
    }
}
