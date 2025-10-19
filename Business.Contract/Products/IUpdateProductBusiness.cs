using Business.Models;
using Business.Models.Products.Update;

namespace Business.Contract.Products
{
    public interface IUpdateProductBusiness
    {
        Task<ResponseBase<UpdateProductDto>> UpdateAsync(UpdateProductDto dto);
    }
}
