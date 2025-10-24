using Business.Contract.Products;
using Business.Models;
using Business.Models.Products.Read;
using Business.Products.Read.Mapper;
using Repository.Contract.Products;

namespace Business.Products.Read
{
    /// <summary>
    /// Camada de negócios responsavel pela leitura de pedidos
    /// </summary>
    public class ReadProductBusiness : IReadProductBusiness
    {
        private readonly IReadProductRepository repository;

        public ReadProductBusiness(IReadProductRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Pesquisa produtos
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<IEnumerable<ReadProductResponseDto>>> FindAllAsync()
        {
            var response = await repository.FindAllAsync();
            return new() { Data = response is not null ? ReadProductsMapper.MapResponse(response) : null };
        }

        /// <summary>
        /// Pesquisa produto pelo identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseBase<ReadProductResponseDto>> FindByIdAsync(int id)
        {
            var response = await repository.FindByIdAsync(id);
            return new() { Data = response is not null ? ReadProductsMapper.MapResponse(response) : null };
        }

        /// <summary>
        /// Pesquisa produtos que contem o nome
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<ResponseBase<IEnumerable<ReadProductResponseDto>>> FindByNameAsync(string name)
        {
            var response = await repository.FindByNameAsync(name);
            return new() { Data = response is not null ? ReadProductsMapper.MapResponse(response) : null };
        }

        /// <summary>
        /// Total de registros
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<int?>> TotalRecordsAsync()
        {
            var totalRecords = await repository.TotalRecordsAsync();
            return new() { Data = totalRecords };
        }
    }
}
