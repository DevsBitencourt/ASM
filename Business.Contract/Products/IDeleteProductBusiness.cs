using Business.Models;

namespace Business.Contract.Products
{
    public interface IDeleteProductBusiness
    {
        Task<ResponseBase<bool>> DeleteAsync(int id);
    }
}
