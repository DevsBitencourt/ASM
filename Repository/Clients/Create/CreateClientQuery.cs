namespace Repository.Clients.Create
{
    /// <summary>
    /// Classe responsavel por armazenar os comando sql
    /// </summary>
    internal static class CreateClientQuery
    {
        internal static string Create()
        {
            return @"INSERT INTO CLIENTS(ID_CLIENTS,
                                         NAME, 
                                         DOCUMENT, 
                                         EMAIL, 
                                         TELEPHONE) 
                     VALUES(@id, @name, @document, @email, @telephone)";
        }
    }
}
