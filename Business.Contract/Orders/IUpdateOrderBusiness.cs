using Business.Models;
using Business.Models.Orders.Update;

namespace Business.Contract.Orders
{
    public interface IUpdateOrderBusiness
    {
        Task<ResponseBase<UpdateOrderResponseDto>> UpdateAsync(UpdateOrderRequestDto model);
    }
}
