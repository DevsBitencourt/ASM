namespace Repository.Orders.Create
{
    internal class CreateOrderQuery
    {
        public static string Command()
        {
            return @"INSERT INTO ORDERS(ID_ORDERS, IDFK_CLIENTS, DATE, STATUS) VALUES (@id, @idClient, @date, @status)";
        }
    }
}
