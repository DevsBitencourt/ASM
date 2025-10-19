using Repository.Models.OrdersItems;

namespace Repository.Contract.OrdersItems
{
    public interface IUpdateOrderItemRepository
    {
        Task<OrderItemModel?> UpdateAsync(OrderItemModel order);
    }
}
