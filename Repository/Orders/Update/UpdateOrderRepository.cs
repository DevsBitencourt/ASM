using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Orders;
using Repository.Models.Orders;
using Repository.SQLServer;

namespace Repository.Orders.Update
{
    /// <summary>
    /// Classe responsavel por persistir a atualizacao de pedidos
    /// </summary>
    public class UpdateOrderRepository : ConnectionSql, IUpdateOrderRepository
    {
        public UpdateOrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<OrderModel?> UpdateAsync(OrderModel order)
        {
            try
            {
                await using var connection = CreateConnection();
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
