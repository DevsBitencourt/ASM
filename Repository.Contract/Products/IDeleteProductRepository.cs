namespace Repository.Contract.Products
{
    public interface IDeleteProductRepository
    {
        Task<bool> DeleteAsync(int id);
    }
}
