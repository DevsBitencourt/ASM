namespace Repository.Orders.Delete
{
    /// <summary>
    /// Classe responsavel por armazenar os comando sql
    /// </summary>
    internal class DeleteOrderQuery
    {
        public static string Command()
        {
            return "DELETE FROM ORDERS WHERE ID_ORDERS = @id";
        }
    }
}
