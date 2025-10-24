using Business.Models.Orders.Update;
using Repository.Models.Orders;
using Repository.Models.Orders.Enum;

namespace Business.Orders.Update.Mapper
{

    /// <summary>
    /// Classe responsavel por realizar o mapeamento dos dados de pedidos
    /// </summary>
    internal class UpdateOrderMapper
    {
        /// <summary>
        /// Mapeamento da model de persistencia para o dto de saida
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static UpdateOrderResponseDto MapResponse(OrderModel model)
        {
            return new()
            {
                Id = model.IdOrder,
                IdClient = model.IdClient,
                Status = (int)model.Status
            };
        }

        /// <summary>
        /// Mapeamento da dto de entrada para a model de persistencia
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static OrderModel MapRequest(UpdateOrderRequestDto dto)
        {
            return new()
            {
                IdOrder = dto.Id,
                IdClient = dto.IdClient,
                Status = (EOrder)dto.Status
            };
        }
    }
}
