using Business.Models.Orders.Read;
using Repository.Models.Orders.Read;

namespace Business.Orders.Read.Mapper
{
    internal class ReadOrderMapper
    {
        public static IEnumerable<ReadOrderResposeDto> MapResponse(IEnumerable<ReadOrderModel> model)
        {
            return model.Select(x => MapResponse(x));
        }

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
