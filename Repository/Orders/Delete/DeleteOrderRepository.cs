using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Orders;
using Repository.SQLServer;

namespace Repository.Orders.Delete
{
    public class DeleteOrderRepository : ConnectionSql, IDeleteOrderRepository
    {
        public DeleteOrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await using var connection = new SqlConnection(ConnectioString);
                var response = await connection.ExecuteAsync(DeleteOrderQuery.Command(), new { id });

                return response > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
