namespace Repository.Contract.Orders
{
    public interface IDeleteOrderRepository
    {
        Task<bool> DeleteAsync(int id);
    }
}
