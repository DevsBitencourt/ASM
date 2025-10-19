using Business.Models;
using Business.Models.Products.Read;

namespace Business.Contract.Products
{
    public interface IReadProductBusiness
    {
        Task<ResponseBase<IEnumerable<ReadProductResponseDto>>> FindAllAsync();
        Task<ResponseBase<ReadProductResponseDto>> FindByIdAsync(int id);
        Task<ResponseBase<IEnumerable<ReadProductResponseDto>>> FindByNameAsync(string name);
        Task<ResponseBase<int?>> TotalRecordsAsync();
    }
}
