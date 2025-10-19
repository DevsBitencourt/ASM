using Repository.Models.Orders;

namespace Repository.Contract.Orders
{
    public interface IUpdateOrderRepository
    {
        Task<OrderModel?> UpdateAsync(OrderModel order);
    }
}
