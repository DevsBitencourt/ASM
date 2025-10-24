using Business.Models.Orders.Create;
using Repository.Models.Orders;
using Repository.Models.Orders.Enum;

namespace Business.Orders.Create.Mapper
{
    /// <summary>
    /// Classe responsavel por realizar o mapeamento dos dados de pedidos
    /// </summary>
    public class CreateOrderMapper
    {
        /// <summary>
        /// Mapeamento da dto de entrada para a model de persistencia
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static OrderModel MapRequest(CreateOrderRequestDto dto)
        {
            return new OrderModel
            {
                IdClient = dto.IdClient,
                Date = DateTime.Now,
                Status = EOrder.EmAberto
            };
        }

        /// <summary>
        /// Mapeamento da model de persistencia para o dto de saida
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static CreateOrderRespondeDto MapResponse(OrderModel model)
        {
            return new()
            {
                Id = model.IdOrder,
                IdClient = model.IdClient,
                Date = model.Date,
                Status = (int)model.Status
            };
        }
    }
}
