using Business.Contract.OrdersItems;
using Business.Models;
using Repository.Contract.OrdersItems;

namespace Business.OrdersItems
{
    /// <summary>
    /// Camada de negócios responsavel pela exclusão de item do pedido
    /// </summary>
    public class DeleteOrderItemBusiness : IDeleteOrderItemBusiness
    {
        private readonly IDeleteOrderItemRepository repository;

        public DeleteOrderItemBusiness(IDeleteOrderItemRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Exclui item de pedido
        /// </summary>
        /// <param name="id">Identificador do pedido</param>
        /// <param name="idProduct">Identificador do produto</param>
        /// <returns></returns>
        public async Task<ResponseBase<bool>> DeleteAsync(int id, int idProduct)
        {
            var response = await repository.DeleteAsync(id, idProduct);
            return new() { Data = response };
        }
    }
}
