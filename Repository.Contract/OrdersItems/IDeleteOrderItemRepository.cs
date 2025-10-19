namespace Repository.Contract.OrdersItems
{
    public interface IDeleteOrderItemRepository
    {
        Task<bool> DeleteAsync(int id, int idProduct);
    }
}
