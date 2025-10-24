namespace Repository.Clients
{
    /// <summary>
    /// Classe responsavel por armazenar os comando sql
    /// </summary>
    internal static class ReadClientQuery
    {
        #region Methods internals

        internal static string FindAll()
        {
            return @"SELECT ID_CLIENTS As IdClients,
                            NAME,
	                        DOCUMENT,
	                        EMAIL,
	                        TELEPHONE
                       FROM CLIENTS WITH(NOLOCK)";
        }

        internal static string FindById()
        {
            return $@"{FindAll()}
                      WHERE ID_CLIENTS = @ID_CLIENTS";
        }

        internal static string FindByName()
        {
            return $@"{FindAll()}
                      WHERE NAME LIKE CONCAT('%', @NAME, '%')";
        }

        internal static string TotalRecords()
        {
            var query = FindAll();
            var posFrom = query.IndexOf("FROM CLIENTS");

            return $@"SELECT COUNT(ID_CLIENTS)
                     {query.Substring(posFrom)}";
        }

        #endregion
    }
}
