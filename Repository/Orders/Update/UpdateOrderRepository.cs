using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Orders;
using Repository.Models.Orders;
using Repository.SQLServer;

namespace Repository.Orders.Update
{
    public class UpdateOrderRepository : ConnectionSql, IUpdateOrderRepository
    {
        public UpdateOrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<OrderModel?> UpdateAsync(OrderModel order)
        {
            try
            {
                await using var connection = new SqlConnection(ConnectioString);
                var response = await connection.ExecuteAsync(UpdateOrderQuery.Command(), new { id = order.IdOrder, status = (int)order.Status });
                return order;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
