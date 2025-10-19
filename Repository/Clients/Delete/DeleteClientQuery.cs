namespace Repository.Clients.Delete
{
    internal class DeleteClientQuery
    {
        internal static string DeleteById()
        {
            return @"DELETE FROM CLIENTS WHERE ID_CLIENTS = @id";
        }
    }
}
