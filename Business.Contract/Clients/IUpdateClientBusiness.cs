using Business.Models;
using Business.Models.Clients.Update;

namespace Business.Contract.Clients.Update
{
    public interface IUpdateClientBusiness
    {
        Task<ResponseBase<UpdateClientDto>> UpdateAsync(UpdateClientDto entity);
    }
}
