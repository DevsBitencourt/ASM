using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Orders;
using Repository.SQLServer;

namespace Repository.Orders.Delete
{
    /// <summary>
    /// Classe responsavel por persistir a exclusao de pedidos
    /// </summary>
    public class DeleteOrderRepository : ConnectionSql, IDeleteOrderRepository
    {
        public DeleteOrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await using var connection = CreateConnection();
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
