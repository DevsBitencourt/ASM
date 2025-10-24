using Microsoft.Extensions.Configuration;
using Repository.Contract.Orders;
using Repository.Models.Orders;
using Repository.SQLServer;
using static Dapper.SqlMapper;

namespace Repository.Orders.Create
{
    /// <summary>
    /// Classe responsavel por persistir a inclusao de pedidos
    /// </summary>
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
                await using var connection = CreateConnection();
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
