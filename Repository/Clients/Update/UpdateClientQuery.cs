namespace Repository.Clients.Update
{
    internal class UpdateClientQuery
    {
        internal static string Update()
        {
            return @"UPDATE CLIENTS SET NAME = @name, EMAIL = @email, DOCUMENT = @document, TELEPHONE = @telephone WHERE ID_CLIENTS = @id";
        }
    }
}
