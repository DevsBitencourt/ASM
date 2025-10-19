using Business.Contract.Orders;
using Business.Models;
using Business.Models.Orders.Create;
using Business.Orders.Create.Mapper;
using Repository.Contract.Orders;

namespace Business.Orders.Create
{
    public class CreateOrderBusiness : ICreateOrderBusiness
    {
        private readonly ICreateOrderRepository repository;

        public CreateOrderBusiness(ICreateOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<CreateOrderRespondeDto>> CreateAsync(CreateOrderRequestDto model)
        {
            try
            {
                var input = CreateOrderMapper.MapRequest(model);
                var response = await repository.CreateAsync(input);
                return new() { Data = response is not null ? CreateOrderMapper.MapResponse(response) : null };
            }
            catch (Exception)
            {
                return new() { Errors = "Ocorreu um erro não tratado" };
            }
        }
    }
}
