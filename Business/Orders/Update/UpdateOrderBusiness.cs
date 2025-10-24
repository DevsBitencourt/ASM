using Business.Contract.Orders;
using Business.Models;
using Business.Models.Orders.Update;
using Business.Orders.Update.Mapper;
using Repository.Contract.Orders;

namespace Business.Orders.Update
{
    /// <summary>
    /// Camada de negócios responsavel pela atualização de pedidos
    /// </summary>
    public class UpdateOrderBusiness : IUpdateOrderBusiness
    {
        private readonly IUpdateOrderRepository repository;

        public UpdateOrderBusiness(IUpdateOrderRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Atualizar pedidos 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
