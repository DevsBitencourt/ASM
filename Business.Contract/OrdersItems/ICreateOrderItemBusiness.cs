using Business.Models;
using Business.Models.OrdersItems;

namespace Business.Contract.OrdersItems
{
    public interface ICreateOrderItemBusiness
    {
        Task<ResponseBase<OrderItemDto>> CreateAsync(OrderItemDto dto);
    }
}
