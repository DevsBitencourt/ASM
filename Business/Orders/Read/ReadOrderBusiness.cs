using Business.Contract.Orders;
using Business.Models;
using Business.Models.Orders.Read;
using Business.Orders.Read.Mapper;
using Repository.Contract.Orders;

namespace Business.Orders.Read
{
    public class ReadOrderBusiness : IReadOrderBusiness
    {
        private readonly IReadOrderRepository repository;

        public ReadOrderBusiness(IReadOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<IEnumerable<ReadOrderResposeDto>>> FindAllAsync()
        {
            var response = await repository.FindAllAsync();
            return new() { Data = response is not null ? ReadOrderMapper.MapResponse(response) : null };
        }

        public async Task<ResponseBase<ReadOrderResposeDto>> FindByIdAsync(int id)
        {
            var response = await repository.FindByIdAsync(id);
            return new() { Data = response is not null ? ReadOrderMapper.MapResponse(response) : null };
        }

        public async Task<ResponseBase<IEnumerable<ReadOrderResposeDto>>> FindByNameAsync(string name)
        {
            var response = await repository.FindByNameAsync(name);
            return new() { Data = response is not null ? ReadOrderMapper.MapResponse(response) : null };
        }

        public async Task<ResponseBase<int?>> TotalRecordsAsync()
        {
            var totalRecords = await repository.TotalRecordsAsync();
            return new() { Data = totalRecords };
        }
    }
}
