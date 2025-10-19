using Repository.Models.Clients;

namespace Repository.Contract.Clients
{
    public interface ICreateClientRepository
    {
        Task<ClientModel?> CreateAsync(ClientModel entity);
    }
}
