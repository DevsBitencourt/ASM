namespace Repository.Orders.Read
{
    /// <summary>
    /// Classe responsavel por armazenar os comando sql
    /// </summary>
    internal class ReadOrderQuery
    {
        #region Methods internals

        internal static string FindAll()
        {
            return @"SELECT o.ID_ORDERS as Id,
	                        o.DATE,
	                        o.STATUS,
	                        c.NAME,
	                        c.DOCUMENT,
                            COALESCE(i.IDFK_ORDERS,0) as IDFK_ORDERS,
	                        i.SEQUENCE,
							i.AMOUNT,
							i.IDFK_PRODUCTS as ProductCode,
							p.NAME as ProductName,
                            p.PRICE as ProductPrice
                       FROM ORDERS o WITH(NOLOCK)
                      INNER JOIN CLIENTS c WITH(NOLOCK)
                         ON c.ID_CLIENTS = o.IDFK_CLIENTS
					   LEFT JOIN ORDERS_ITEMS i WITH(NOLOCK)
					     ON i.IDFK_ORDERS = o.ID_ORDERS
				       LEFT JOIN PRODUCTS p WITH(NOLOCK)
				 	     ON p.ID_PRODUCTS = i.IDFK_PRODUCTS";
        }

        internal static string FindById()
        {
            return $@"{FindAll()}
                      WHERE o.ID_ORDERS = @id";
        }

        internal static string FindByName()
        {
            return $@"{FindAll()}
                      WHERE c.NAME LIKE CONCAT('%', @name, '%')";
        }

        internal static string TotalRecords()
        {
            var query = FindAll();
            var posFrom = query.IndexOf("FROM ORDERS");

            return $@"SELECT COUNT(o.ID_ORDERS)
                     {query.Substring(posFrom)}";
        }

        #endregion
    }
}
