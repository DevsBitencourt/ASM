using Business.Shared.Exceptions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.OrdersItems;
using Repository.Models.OrdersItems;
using Repository.SQLServer;

namespace Repository.OrdersItems.Update
{
    public class UpdateOrderItemRepository : ConnectionSql, IUpdateOrderItemRepository
    {
        public UpdateOrderItemRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<OrderItemModel?> UpdateAsync(OrderItemModel order)
        {

            try
            {
                await using var connection = new SqlConnection(ConnectioString);
                var response = await connection.ExecuteAsync(UpdateOrderItemQuery.Command(), new { id = order.IdOrder, order.idProduct, amount = order.Amount });

                return order;
            }
            catch (SqlException ex)
            {
                throw ex.Number switch
                {
                    547 => HandleForeignKeyError(ex),
                    2627 or 2601 => new InvalidOperationException("Já existe um item com estes dados.", ex),
                    515 => new InvalidOperationException("Todos os campos obrigatórios devem ser preenchidos.", ex),
                    8152 => new InvalidOperationException("Um ou mais valores excedem o tamanho permitido.", ex),
                    245 => new InvalidOperationException("Valor inválido para o campo numérico.", ex),
                    _ => new InvalidOperationException($"Erro ao executar operação: {ex.Message}", ex)
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static ForeignKeyException HandleForeignKeyError(SqlException ex)
        {
            return ex.Message switch
            {
                var msg when msg.Contains("FK_ORDERS_ITEMS_ORDERS")
                    => new ForeignKeyException("O pedido informado não existe no sistema."),
                var msg when msg.Contains("FK_ORDERS_ITEMS_PRODUCTS")
                    => new ForeignKeyException("O produto informado não existe no sistema."),
                _ => new ForeignKeyException("Erro de chave estrangeira.")
            };
        }

    }
}
