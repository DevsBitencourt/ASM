using Business.Contract.Orders;
using Business.Models;
using Business.Models.Orders.Read;
using Business.Orders.Read.Mapper;
using Repository.Contract.Orders;

namespace Business.Orders.Read
{
    /// <summary>
    /// Camada de negócios responsavel pela pesquisa de pedidos
    /// </summary>
    public class ReadOrderBusiness : IReadOrderBusiness
    {
        private readonly IReadOrderRepository repository;

        public ReadOrderBusiness(IReadOrderRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Pesquisa pedidos do sistema
        /// </summary>
        /// <returns>Lista de todos os pedidos do sistema</returns>
        public async Task<ResponseBase<IEnumerable<ReadOrderResposeDto>>> FindAllAsync()
        {
            var response = await repository.FindAllAsync();
            return new() { Data = response is not null ? ReadOrderMapper.MapResponse(response) : null };
        }

        /// <summary>
        /// Pesquisa pedido com base no identificador 
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna pedido</returns>
        public async Task<ResponseBase<ReadOrderResposeDto>> FindByIdAsync(int id)
        {
            var response = await repository.FindByIdAsync(id);
            return new() { Data = response is not null ? ReadOrderMapper.MapResponse(response) : null };
        }

        /// <summary>
        /// Pesquisa de pedidos com base no nome do cliente
        /// </summary>
        /// <param name="name">Nome</param>
        /// <returns>Lista de pedidos com nome de cliente contendo o nome informado</returns>
        public async Task<ResponseBase<IEnumerable<ReadOrderResposeDto>>> FindByNameAsync(string name)
        {
            var response = await repository.FindByNameAsync(name);
            return new() { Data = response is not null ? ReadOrderMapper.MapResponse(response) : null };
        }

        /// <summary>
        /// Total de pedidos no sistema
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<int?>> TotalRecordsAsync()
        {
            var totalRecords = await repository.TotalRecordsAsync();
            return new() { Data = totalRecords };
        }
    }
}
