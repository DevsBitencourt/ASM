using Business.Models.Clients.Update;

namespace Business.Clients.Update.Mapper
{
    internal class UpdateClientMapper
    {
        public static Repository.Models.Clients.ClientModel MapRequest(UpdateClientDto client)
        {
            return new Repository.Models.Clients.ClientModel()
            {
                IdClients = client.Id,
                Name = client.Name,
                Document = client.Document,
                Email = client.Email,
                Telephone = client.Telephone
            };
        }

        public static UpdateClientDto MapResponse(Repository.Models.Clients.ClientModel client)
        {
            return new UpdateClientDto()
            {
                Id = client.IdClients,
                Name = client.Name,
                Document = client.Document,
                Email = client.Email,
                Telephone = client.Telephone
            };
        }
    }
}
