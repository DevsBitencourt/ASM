using Repository.Models.Orders;

namespace Repository.Contract.Orders
{
    public interface ICreateOrderRepository
    {
        Task<OrderModel?> CreateAsync(OrderModel order);
    }
}
