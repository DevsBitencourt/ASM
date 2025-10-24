namespace Repository.Clients.Delete
{
    /// <summary>
    /// Classe responsavel por armazenar os comando sql
    /// </summary>
    internal class DeleteClientQuery
    {
        internal static string DeleteById()
        {
            return @"DELETE FROM CLIENTS WHERE ID_CLIENTS = @id";
        }
    }
}
