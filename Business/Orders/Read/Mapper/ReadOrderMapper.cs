using Business.Models.Orders.Read;
using Repository.Models.Orders.Read;

namespace Business.Orders.Read.Mapper
{

    /// <summary>
    /// Classe responsavel por realizar o mapeamento dos dados de pedidos
    /// </summary>
    internal class ReadOrderMapper
    {
        /// <summary>
        /// Mapeamento da model de persistencia para o dto de saida
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static IEnumerable<ReadOrderResposeDto> MapResponse(IEnumerable<ReadOrderModel> model)
        {
            return model.Select(x => MapResponse(x));
        }

        /// <summary>
        /// Mapeamento da model de persistencia para o dto de saida
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static ReadOrderResposeDto MapResponse(ReadOrderModel model)
        {
            return new ReadOrderResposeDto()
            {
                Id = model.Id,
                Status = (int)model.Status,
                Document = model.Document,
                Date = model.Date,
                Name = model.Name,
                Total = model.Total,
                Items = model.Items?.Select(i => MapItemResponse(i))
            };
        }

        /// <summary>
        /// Mapeamento da model de persistencia para o dto de saida
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static ReadOrderItemResponseDto MapItemResponse(ReadOrderItemModel dto)
        {
            return new ReadOrderItemResponseDto()
            {
                Sequence = dto.Sequence,
                Amount = dto.Amount,
                ProductCode = dto.ProductCode,
                ProductName = dto.ProductName,
                ProductPrice = dto.ProductPrice
            };
        }
    }
}
