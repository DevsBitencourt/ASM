namespace Repository.Orders.Create
{
    /// <summary>
    /// Classe responsavel por armazenar os comando sql
    /// </summary>
    internal class CreateOrderQuery
    {
        public static string Command()
        {
            return @"INSERT INTO ORDERS(ID_ORDERS, IDFK_CLIENTS, DATE, STATUS) VALUES (@id, @idClient, @date, @status)";
        }
    }
}
