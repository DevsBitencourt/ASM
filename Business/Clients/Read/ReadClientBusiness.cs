using Business.Contract.Clients;
using Business.Models;
using Business.Models.Clients.Read;
using Repository.Contract.Clients;

namespace Business.Clients.Read
{
    /// <summary>
    /// Camada de negócios responsavel pela busca de clientes
    /// </summary>
    public class ReadClientBusiness : IReadClientBusiness
    {
        private readonly IReadClientsRepository _clientsRepository;

        public ReadClientBusiness(IReadClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        /// <summary>
        /// Pesquisa os clientes
        /// </summary>
        /// <returns>Lista todos os clientes cadastrado no sistema</returns>
        public async Task<ResponseBase<IEnumerable<ReadClientDto>>> FindAllAsync()
        {
            var findAll = await _clientsRepository.FindAllAsync();
            var _mapper = Mapper.ReadClientMapper.MapResponse(findAll);
            return new() { Data = _mapper };
        }

        /// <summary>
        /// Pesquisa cliente pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Cliente solicitado</returns>
        public async Task<ResponseBase<ReadClientDto>> FindByIdAsync(int id)
        {
            var findById = await _clientsRepository.FindByIdAsync(id);
            var mapper = Mapper.ReadClientMapper.MapResponse(findById);
            return new() { Data = mapper };
        }

        /// <summary>
        /// Pesquisa cliente com base no nome, contendo o nome
        /// </summary>
        /// <param name="name">Nome</param>
        /// <returns>Lista de clientes que contenham o nome informado</returns>
        public async Task<ResponseBase<IEnumerable<ReadClientDto>>> FindByNameAsync(string name)
        {
            var findByName = await _clientsRepository.FindByNameAsync(name);
            var mapper = Mapper.ReadClientMapper.MapResponse(findByName);
            return new() { Data = mapper };
        }

        /// <summary>
        /// Quantidade de clientes cadastrados
        /// </summary>
        /// <returns>Total de clientes cadastrados no sistema</returns>
        public async Task<ResponseBase<int?>> TotalRecordsAsync()
        {
            var totalRecords = await _clientsRepository.TotalRecordsAsync();
            return new() { Data = totalRecords };
        }
    }
}
