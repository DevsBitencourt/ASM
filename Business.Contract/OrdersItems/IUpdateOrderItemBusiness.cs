using Business.Models;
using Business.Models.OrdersItems;

namespace Business.Contract.OrdersItems
{
    public interface IUpdateOrderItemBusiness
    {
        Task<ResponseBase<OrderItemDto>> UpdateAsync(OrderItemDto dto);
    }
}
