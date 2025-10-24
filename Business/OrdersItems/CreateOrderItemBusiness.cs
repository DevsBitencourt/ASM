using Business.Contract.OrdersItems;
using Business.Models;
using Business.Models.OrdersItems;
using Business.OrdersItems.Mapper;
using Business.Shared.Exceptions;
using Repository.Contract.OrdersItems;

namespace Business.OrdersItems
{
    /// <summary>
    /// Camada de negócios responsavel pela criação de itens em pedido
    /// </summary>
    public class CreateOrderItemBusiness : ICreateOrderItemBusiness
    {
        private readonly ICreateOrderItemRepository repository;

        public CreateOrderItemBusiness(ICreateOrderItemRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adiciona item ao pedido do cliente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ResponseBase<OrderItemDto>> CreateAsync(OrderItemDto dto)
        {
            try
            {
                var mapper = OrderItemsMapper.Map(dto);
                var response = await repository.CreateAsync(mapper);
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
