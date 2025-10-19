using Repository.Models.OrdersItems;

namespace Repository.Contract.OrdersItems
{
    public interface ICreateOrderItemRepository
    {
        Task<OrderItemModel?> CreateAsync(OrderItemModel order);

    }
}
