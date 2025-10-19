using Business.Contract.Products;
using Business.Models;
using Business.Models.Products.Read;
using Business.Products.Read.Mapper;
using Repository.Contract.Products;

namespace Business.Products.Read
{
    public class ReadProductBusiness : IReadProductBusiness
    {
        private readonly IReadProductRepository repository;

        public ReadProductBusiness(IReadProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<IEnumerable<ReadProductResponseDto>>> FindAllAsync()
        {
            var response = await repository.FindAllAsync();
            return new() { Data = response is not null ? ReadProductsMapper.MapResponse(response) : null };
        }

        public async Task<ResponseBase<ReadProductResponseDto>> FindByIdAsync(int id)
        {
            var response = await repository.FindByIdAsync(id);
            return new() { Data = response is not null ? ReadProductsMapper.MapResponse(response) : null };
        }

        public async Task<ResponseBase<IEnumerable<ReadProductResponseDto>>> FindByNameAsync(string name)
        {
            var response = await repository.FindByNameAsync(name);
            return new() { Data = response is not null ? ReadProductsMapper.MapResponse(response) : null };
        }

        public async Task<ResponseBase<int?>> TotalRecordsAsync()
        {
            var totalRecords = await repository.TotalRecordsAsync();
            return new() { Data = totalRecords };
        }
    }
}
