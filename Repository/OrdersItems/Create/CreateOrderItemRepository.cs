using Business.Shared.Exceptions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Orders;
using Repository.Contract.OrdersItems;
using Repository.Contract.Products;
using Repository.Models.OrdersItems;
using Repository.SQLServer;

namespace Repository.OrdersItems.Create
{
    /// <summary>
    /// Classe responsavel por persistir a inclusao de itens pedido
    /// </summary>
    public class CreateOrderItemRepository : ConnectionSql, ICreateOrderItemRepository
    {
        private readonly IReadOrderRepository repository;
        private readonly IUpdateProductRepository updateProduct;

        public CreateOrderItemRepository(IConfiguration configuration, IReadOrderRepository repository, IUpdateProductRepository updateProduct) : base(configuration)
        {
            this.repository = repository;
            this.updateProduct = updateProduct;
        }

        public async Task<OrderItemModel?> CreateAsync(OrderItemModel order)
        {
            var orders = await repository.FindByIdAsync(order.IdOrder);

            int sequence = 1;

            if (orders is not null)
            {
                if ((orders.Items is not null) && (orders.Items.Count > 0))
                    sequence = orders.Items.Select(i => i.Sequence).Max() + 1;
            }

            try
            {
                await using var connection = CreateConnection();
                var response = await connection.ExecuteAsync(CreateOrderItemQuery.Command(), new { id = order.IdOrder, order.idProduct, sequence, amount = order.Amount });

                await StockMovement(order.idProduct, order.Amount);

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

        private async Task StockMovement(int productId, int amount)
        {
            var product = new Models.Products.ProductModel()
            {
                Id = productId,
                Amount = amount * -1
            };

            await updateProduct.StockMovementAsync(product);
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
