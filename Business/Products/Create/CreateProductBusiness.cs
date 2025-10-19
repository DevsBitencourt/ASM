using Business.Contract.Products;
using Business.Models;
using Business.Models.Products.Create;
using Business.Products.Create.Mapper;
using Repository.Contract.Products;

namespace Business.Products.Create
{
    public class CreateProductBusiness : ICreateProductBusiness
    {
        private readonly ICreateProductRepository repository;

        public CreateProductBusiness(ICreateProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<CreateProductResponseDto>> CreateAsync(CreateProductsRequestDto dto)
        {
            var input = CreateProductMapper.MapRequest(dto);
            var response = await repository.CreateAsync(input);
            return new() { Data = response is not null ? CreateProductMapper.MapResponse(response) : null };
        }
    }
}
