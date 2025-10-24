namespace Repository.OrdersItems.Delete
{
    /// <summary>
    /// Classe responsavel por armazenar os comando sql
    /// </summary>
    internal class DeleteOrderItemQuery
    {
        public static string Command()
        {
            return "DELETE FROM ORDERS_ITEMS WHERE IDFK_ORDERS = @id AND IDFK_PRODUCTS = @idProduct";
        }
    }
}
