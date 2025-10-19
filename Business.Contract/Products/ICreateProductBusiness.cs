using Business.Models;
using Business.Models.Products.Create;

namespace Business.Contract.Products
{
    public interface ICreateProductBusiness
    {
        Task<ResponseBase<CreateProductResponseDto>> CreateAsync(CreateProductsRequestDto dto);
    }
}
