namespace Repository.Clients.Create
{
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
