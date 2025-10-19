using Business.Models;
using Business.Models.Orders.Create;

namespace Business.Contract.Orders
{
    public interface ICreateOrderBusiness
    {
        Task<ResponseBase<CreateOrderRespondeDto>> CreateAsync(CreateOrderRequestDto model);
    }
}
