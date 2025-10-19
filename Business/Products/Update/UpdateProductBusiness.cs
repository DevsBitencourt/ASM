using Business.Contract.Products;
using Business.Models;
using Business.Models.Products.Update;
using Business.Products.Update.Mapper;
using Repository.Contract.Products;

namespace Business.Products.Update
{
    public class UpdateProductBusiness : IUpdateProductBusiness
    {
        private readonly IUpdateProductRepository repository;

        public UpdateProductBusiness(IUpdateProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<UpdateProductDto>> UpdateAsync(UpdateProductDto dto)
        {
            var input = UpdateProductMapper.MapRequest(dto);
            var response = await repository.UpdateAsync(input);
            return new() { Data = response is not null ? UpdateProductMapper.MapResponse(response) : null };
        }

    }
}
