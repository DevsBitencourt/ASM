namespace Repository.Orders.Update
{
    /// <summary>
    /// Classe responsavel por armazenar os comando sql
    /// </summary>
    internal class UpdateOrderQuery
    {
        public static string Command()
        {
            return "UPDATE ORDERS SET STATUS = @status WHERE ID_ORDERS = @id";
        }
    }
}
