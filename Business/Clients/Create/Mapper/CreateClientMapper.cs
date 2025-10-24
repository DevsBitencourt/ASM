using Business.Models.Clients;
using Business.Models.Clients.Create;

namespace Business.Clients.Create.Mapper
{
    /// <summary>
    /// Classe responsavel por realizar o mapeamento dos dados de clientes
    /// </summary>
    public class CreateClientMapper
    {
        /// <summary>
        /// Mapeamento da dto de entrada para a model de persistencia
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Mapeamento da model de persistencia para a dto de saída
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
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
