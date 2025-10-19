using Business.Contract.OrdersItems;
using Business.Models;
using Business.Models.OrdersItems;
using Business.OrdersItems.Mapper;
using Business.Shared.Exceptions;
using Repository.Contract.OrdersItems;

namespace Business.OrdersItems
{
    public class UpdateOrderItemBusiness : IUpdateOrderItemBusiness
    {
        private readonly IUpdateOrderItemRepository repository;

        public UpdateOrderItemBusiness(IUpdateOrderItemRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<OrderItemDto>> UpdateAsync(OrderItemDto dto)
        {
            try
            {
                var mapper = OrderItemsMapper.Map(dto);
                var response = await repository.UpdateAsync(mapper);
                return new() { Data = response is null ? null : OrderItemsMapper.MapResponse(response) };
            }
            catch (InvalidOperationException ex)
            {
                return new() { Errors = new List<string>() { ex.Message } };
            }
            catch (ForeignKeyException ex)
            {
                return new() { Errors = new List<string>() { ex.Message } };
            }
        }
    }
}
