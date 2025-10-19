namespace Repository.Orders.Update
{
    internal class UpdateOrderQuery
    {
        public static string Command()
        {
            return "UPDATE ORDERS SET STATUS = @status WHERE ID_ORDERS = @id";
        }
    }
}
