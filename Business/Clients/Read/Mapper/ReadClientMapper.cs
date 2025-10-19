using Business.Models.Clients.Read;
using Repository.Models.Clients;

namespace Business.Clients.Read.Mapper
{
    internal class ReadClientMapper
    {
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
