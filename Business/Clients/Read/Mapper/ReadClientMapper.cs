using Business.Models.Clients.Read;
using Repository.Models.Clients;

namespace Business.Clients.Read.Mapper
{
    internal class ReadClientMapper
    {
        /// <summary>
        /// Realiza o mapeamento da model para a dto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IEnumerable<ReadClientDto> MapResponse(IEnumerable<ClientModel> model)
        {
            return model.Select(x => new ReadClientDto
            {
                Id = x.IdClients,
                Name = x.Name,
                Document = x.Document,
                Email = x.Email,
                Telephone = x.Telephone
            });
        }

        /// <summary>
        /// Realiza o mapeamento da model para a dto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ReadClientDto MapResponse(ClientModel model)
        {
            return new ReadClientDto
            {
                Id = model.IdClients,
                Name = model.Name,
                Document = model.Document,
                Email = model.Email,
                Telephone = model.Telephone
            };
        }
    }
}
