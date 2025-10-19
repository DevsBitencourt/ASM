using Business.Contract.Orders;
using Business.Models;
using Repository.Contract.Orders;

namespace Business.Orders.Delete
{
    public class DeleteOrderBusiness : IDeleteOrderBusiness
    {
        private readonly IDeleteOrderRepository repository;

        public DeleteOrderBusiness(IDeleteOrderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<bool>> DeleteAsync(int id)
        {
            var response = await repository.DeleteAsync(id);
            return new() { Data = response };
        }

    }
}
