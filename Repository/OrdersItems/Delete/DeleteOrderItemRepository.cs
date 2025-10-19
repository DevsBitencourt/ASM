using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.OrdersItems;
using Repository.SQLServer;

namespace Repository.OrdersItems.Delete
{
    public class DeleteOrderItemRepository : ConnectionSql, IDeleteOrderItemRepository
    {
        public DeleteOrderItemRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> DeleteAsync(int id, int idProduct)
        {
            try
            {
                await using var connection = new SqlConnection(ConnectioString);
                var response = await connection.ExecuteAsync(DeleteOrderItemQuery.Command(), new { id, idProduct });

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
