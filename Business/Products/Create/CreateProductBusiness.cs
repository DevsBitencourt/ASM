using Business.Contract.Products;
using Business.Models;
using Business.Models.Products.Create;
using Business.Products.Create.Mapper;
using Repository.Contract.Products;

namespace Business.Products.Create
{
    /// <summary>
    /// Camada de negócios responsavel pela criacao de produtos
    /// </summary>
    public class CreateProductBusiness : ICreateProductBusiness
    {
        private readonly ICreateProductRepository repository;

        public CreateProductBusiness(ICreateProductRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Criacao de produtos no sistema
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ResponseBase<CreateProductResponseDto>> CreateAsync(CreateProductsRequestDto dto)
        {
            var input = CreateProductMapper.MapRequest(dto);
            var response = await repository.CreateAsync(input);
            return new() { Data = response is not null ? CreateProductMapper.MapResponse(response) : null };
        }
    }
}
