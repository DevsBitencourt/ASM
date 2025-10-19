using Business.Contract.Orders;
using Business.Models;
using Business.Models.Orders.Update;
using Business.Orders.Update.Mapper;
using Repository.Contract.Orders;

namespace Business.Orders.Update
{
    public class UpdateOrderBusiness : IUpdateOrderBusiness
    {
        private readonly IUpdateOrderRepository repository;

        public UpdateOrderBusiness(IUpdateOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<UpdateOrderResponseDto>> UpdateAsync(UpdateOrderRequestDto model)
        {
            var input = UpdateOrderMapper.MapRequest(model);
            var response = await repository.UpdateAsync(input);
            return new()
            {
                Data = response is not null ? UpdateOrderMapper.MapResponse(response) : null
            };
        }
    }
}
