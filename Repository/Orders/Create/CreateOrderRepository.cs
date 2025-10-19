using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Orders;
using Repository.Models.Orders;
using Repository.SQLServer;
using static Dapper.SqlMapper;

namespace Repository.Orders.Create
{
    public class CreateOrderRepository : ConnectionSql, ICreateOrderRepository
    {
        public CreateOrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<OrderModel?> CreateAsync(OrderModel order)
        {
            try
            {
                order.IdOrder = await this.SequenceAsync("SEQUENCE_ORDERS");
                await using var connection = new SqlConnection(ConnectioString);
                var response = await connection.ExecuteAsync(CreateOrderQuery.Command(), new { id = order.IdOrder, idClient = order.IdClient, date = order.Date, status = (int)order.Status });

                return order;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
