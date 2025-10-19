using Business.Models.OrdersItems;
using Repository.Models.OrdersItems;

namespace Business.OrdersItems.Mapper
{
    public class OrderItemsMapper
    {
        public static OrderItemDto MapResponse(OrderItemModel model)
        {
            return new OrderItemDto()
            {
                IdOrder = model.IdOrder,
                idProduct = model.idProduct,
                Amount = model.Amount
            };
        }

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
