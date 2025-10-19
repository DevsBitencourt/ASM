using Business.Contract.Clients;
using Business.Models;
using Business.Models.Clients.Read;
using Repository.Contract.Clients;

namespace Business.Clients.Read
{
    public class ReadClientBusiness : IReadClientBusiness
    {
        private readonly IReadClientsRepository _clientsRepository;

        public ReadClientBusiness(IReadClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<ResponseBase<IEnumerable<ReadClientDto>>> FindAllAsync()
        {
            var findAll = await _clientsRepository.FindAllAsync();
            var _mapper = Mapper.ReadClientMapper.MapResponse(findAll);
            return new() { Data = _mapper };
        }

        public async Task<ResponseBase<ReadClientDto>> FindByIdAsync(int id)
        {
            var findById = await _clientsRepository.FindByIdAsync(id);
            var mapper = Mapper.ReadClientMapper.MapResponse(findById);
            return new() { Data = mapper };
        }

        public async Task<ResponseBase<IEnumerable<ReadClientDto>>> FindByNameAsync(string name)
        {
            var findByName = await _clientsRepository.FindByNameAsync(name);
            var mapper = Mapper.ReadClientMapper.MapResponse(findByName);
            return new() { Data = mapper };
        }

        public async Task<ResponseBase<int?>> TotalRecordsAsync()
        {
            var totalRecords = await _clientsRepository.TotalRecordsAsync();
            return new() { Data = totalRecords };
        }
    }
}
