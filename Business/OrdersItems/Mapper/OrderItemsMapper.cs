using Business.Models.OrdersItems;
using Repository.Models.OrdersItems;

namespace Business.OrdersItems.Mapper
{
    /// <summary>
    /// Camada responsável pelo mapeamento de itens de pedido
    /// </summary>
    public class OrderItemsMapper
    {
        /// <summary>
        /// Responsavel pelo mapeamento da model de persistencia para o dto de saida
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static OrderItemDto MapResponse(OrderItemModel model)
        {
            return new OrderItemDto()
            {
                IdOrder = model.IdOrder,
                idProduct = model.idProduct,
                Amount = model.Amount
            };
        }

        /// <summary>
        /// Responsavel pelo mapeameto do dto de entrada para a model de persistencia
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static OrderItemModel Map(OrderItemDto model)
        {
            return new()
            {
                IdOrder = model.IdOrder,
                idProduct = model.idProduct,
                Amount = model.Amount
            };
        }

    }
}
