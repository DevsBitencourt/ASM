using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Orders;
using Repository.Contract.OrdersItems;
using Repository.Contract.Products;
using Repository.SQLServer;

namespace Repository.OrdersItems.Delete
{
    public class DeleteOrderItemRepository : ConnectionSql, IDeleteOrderItemRepository
    {

        private readonly IReadOrderRepository repository;
        private readonly IUpdateProductRepository updateProduct;

        public DeleteOrderItemRepository(IConfiguration configuration, IReadOrderRepository repository, IUpdateProductRepository updateProduct) : base(configuration)
        {
            this.repository = repository;
            this.updateProduct = updateProduct;
        }

        public async Task<bool> DeleteAsync(int id, int idProduct)
        {
            try
            {
                var orders = await repository.FindByIdAsync(id);

                int amount = 0;
                if (orders is not null)
                {
                    if ((orders.Items is not null) && (orders.Items.Count > 0))
                        amount = Convert.ToInt32(orders.Items.Select(i => i.Amount).FirstOrDefault(0));
                }

                await using var connection = new SqlConnection(ConnectioString);
                var response = await connection.ExecuteAsync(DeleteOrderItemQuery.Command(), new { id, idProduct });

                await StockMovement(idProduct, amount);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task StockMovement(int productId, int amount)
        {
            var product = new Models.Products.ProductModel()
            {
                Id = productId,
                Amount = amount
            };

            await updateProduct.StockMovementAsync(product);
        }
    }
}
