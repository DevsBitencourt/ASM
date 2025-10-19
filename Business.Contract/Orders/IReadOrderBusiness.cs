using Business.Models;
using Business.Models.Orders.Read;

namespace Business.Contract.Orders
{
    public interface IReadOrderBusiness
    {
        Task<ResponseBase<IEnumerable<ReadOrderResposeDto>>> FindAllAsync();
        Task<ResponseBase<ReadOrderResposeDto>> FindByIdAsync(int id);
        Task<ResponseBase<IEnumerable<ReadOrderResposeDto>>> FindByNameAsync(string name);
        Task<ResponseBase<int?>> TotalRecordsAsync();
    }
}
