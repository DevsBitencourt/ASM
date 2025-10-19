using Business.Models;

namespace Business.Contract.Orders
{
    public interface IDeleteOrderBusiness
    {
        Task<ResponseBase<bool>> DeleteAsync(int id);
    }
}
