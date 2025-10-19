using Business.Models;

namespace Business.Contract.Clients
{
    public interface IDeleteClientBusiness
    {
        Task<ResponseBase<bool>> DeleteAsync(int id);
    }
}
