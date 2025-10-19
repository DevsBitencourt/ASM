namespace Repository.Orders.Delete
{
    internal class DeleteOrderQuery
    {
        public static string Command()
        {
            return "DELETE FROM ORDERS WHERE ID_ORDERS = @id";
        }
    }
}
