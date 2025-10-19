using Business.Models;
using Business.Models.Clients.Create;

namespace Business.Contract.Clients
{
    public interface ICreateClientBusiness
    {
        Task<ResponseBase<CreateClientResponseDto>> CreateAsync(CreateClientDto entity);
    }
}
