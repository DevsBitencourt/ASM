using Business.Models.Orders.Update;
using Repository.Models.Orders;
using Repository.Models.Orders.Enum;

namespace Business.Orders.Update.Mapper
{
    internal class UpdateOrderMapper
    {
        public static UpdateOrderResponseDto MapResponse(OrderModel model)
        {
            return new()
            {
                Id = model.IdOrder,
                IdClient = model.IdClient,
                Status = (int)model.Status
            };
        }

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
