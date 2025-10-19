using Business.Contract.OrdersItems;
using Business.Models;
using Repository.Contract.OrdersItems;

namespace Business.OrdersItems
{
    public class DeleteOrderItemBusiness : IDeleteOrderItemBusiness
    {
        private readonly IDeleteOrderItemRepository repository;

        public DeleteOrderItemBusiness(IDeleteOrderItemRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<bool>> DeleteAsync(int id, int idProduct)
        {
            var response = await repository.DeleteAsync(id, idProduct);
            return new() { Data = response };
        }
    }
}
