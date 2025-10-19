using Business.Models.Orders.Create;
using Repository.Models.Orders;
using Repository.Models.Orders.Enum;

namespace Business.Orders.Create.Mapper
{
    public class CreateOrderMapper
    {
        public static OrderModel MapRequest(CreateOrderRequestDto dto)
        {
            return new OrderModel
            {
                IdClient = dto.IdClient,
                Date = DateTime.Now,
                Status = EOrder.EmAberto
            };
        }

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
