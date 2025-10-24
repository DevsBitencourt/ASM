using Business.Contract.OrdersItems;
using Business.Models;
using Business.Models.OrdersItems;
using Business.OrdersItems.Mapper;
using Business.Shared.Exceptions;
using Repository.Contract.OrdersItems;

namespace Business.OrdersItems
{
    /// <summary>
    /// Camada de negócios responsavel pela atualização de item no pedido
    /// </summary>
    public class UpdateOrderItemBusiness : IUpdateOrderItemBusiness
    {
        private readonly IUpdateOrderItemRepository repository;

        public UpdateOrderItemBusiness(IUpdateOrderItemRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Atualiza item do pedido com base no produto informado
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
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
