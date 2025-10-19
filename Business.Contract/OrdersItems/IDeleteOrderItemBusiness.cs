using Business.Models;

namespace Business.Contract.OrdersItems
{
    public interface IDeleteOrderItemBusiness
    {
        Task<ResponseBase<bool>> DeleteAsync(int id, int idProduct);
    }
}
