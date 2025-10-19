using Repository.Models.Clients;

namespace Repository.Contract.Clients
{
    public interface IUpdateClientRepository
    {
        Task<ClientModel> UpdateAsync(ClientModel entity);
    }
}
