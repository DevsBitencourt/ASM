namespace Repository.Products.Read
{
    internal class ReadProductQuery
    {
        public static string FindAll()
        {
            return $@"SELECT ID_PRODUCTS as Id,
                             NAME,
	                         AMOUNT,
	                         PRICE
                        FROM PRODUCTS WITH(NOLOCK)";
        }

        public static string FindById()
        {
            return $@"{FindAll()}
                      WHERE ID_PRODUCTS = @id";
        }

        public static string FindByName()
        {
            return $@"{FindAll()}
                      WHERE NAME LIKE CONCAT('%', @name, '%')";
        }

        internal static string TotalRecords()
        {
            var query = FindAll();
            var posFrom = query.IndexOf("FROM PRODUCTS");

            return $@"SELECT COUNT(ID_PRODUCTS)
                     {query.Substring(posFrom)}";
        }
    }
}
