using Business.Models.Clients;
using Business.Models.Clients.Create;

namespace Business.Clients.Create.Mapper
{
    public class CreateClientMapper
    {
        public static Repository.Models.Clients.ClientModel MapRequest(ClientDto client)
        {
            return new Repository.Models.Clients.ClientModel()
            {
                Name = client.Name,
                Document = client.Document,
                Email = client.Email,
                Telephone = client.Telephone
            };
        }

        public static CreateClientResponseDto MapResponse(Repository.Models.Clients.ClientModel client)
        {
            return new CreateClientResponseDto()
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
