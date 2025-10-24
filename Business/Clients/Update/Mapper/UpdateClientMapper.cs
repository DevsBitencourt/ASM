using Business.Models.Clients.Update;

namespace Business.Clients.Update.Mapper
{
    internal class UpdateClientMapper
    {
        /// <summary>
        /// Realiza o mapeamento do dto de entrada para a model de persistencia
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Realiza o mapeamento da model de persistencia para o dto de saida
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
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
