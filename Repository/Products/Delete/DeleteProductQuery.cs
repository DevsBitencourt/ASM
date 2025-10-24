namespace Repository.Products.Delete
{
    /// <summary>
    /// Classe responsavel por armazenar os comando sql
    /// </summary>
    internal class DeleteProductQuery
    {
        public static string Delete()
        {
            return $"DELETE FROM PRODUCTS WHERE ID_PRODUCTS = @id";
        }
    }
}
