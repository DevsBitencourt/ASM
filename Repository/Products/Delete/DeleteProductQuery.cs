namespace Repository.Products.Delete
{
    internal class DeleteProductQuery
    {
        public static string Delete()
        {
            return $"DELETE FROM PRODUCTS WHERE ID_PRODUCTS = @id";
        }
    }
}
