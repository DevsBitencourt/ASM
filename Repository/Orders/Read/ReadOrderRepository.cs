using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Orders;
using Repository.Models.Orders.Read;
using Repository.SQLServer;

namespace Repository.Orders.Read
{

    /// <summary>
    /// Classe responsavel por pesquisar pedidos
    /// </summary>
    public class ReadOrderRepository : ConnectionSql, IReadOrderRepository
    {
        public ReadOrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<ReadOrderModel>> FindAllAsync()
        {
            try
            {
                var orderDictionary = new Dictionary<int, ReadOrderModel>();

                await using var connection = CreateConnection();

                var response = await connection.QueryAsync<ReadOrderModel, ReadOrderItemModel, ReadOrderModel>(ReadOrderQuery.FindAll(),
                    (order, orderItem) =>
                    {

                        if (!orderDictionary.TryGetValue(order.Id, out ReadOrderModel orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.Items = new List<ReadOrderItemModel>();
                            orderDictionary.Add(orderEntry.Id, orderEntry);
                        }

                        if (orderItem.Sequence > 0)
                        {
                            orderEntry?.Items?.Add(orderItem);
                        }

                        return orderEntry;

                    },
                    splitOn: "IDFK_ORDERS"
                    );

                return orderDictionary.Values;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public async Task<ReadOrderModel?> FindByIdAsync(int id)
        {
            try
            {
                await using var connection = CreateConnection();
                return await connection.QueryFirstAsync<ReadOrderModel>(ReadOrderQuery.FindById(), new { id });
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ReadOrderModel>> FindByNameAsync(string name)
        {
            try
            {
                await using var connection = CreateConnection();
                return await connection.QueryAsync<ReadOrderModel>(ReadOrderQuery.FindByName(), new { name });
            }
            catch (Exception)
            {
                return [];
            }
        }

        public async Task<int?> TotalRecordsAsync()
        {
            return await this.TotalRecords(ReadOrderQuery.TotalRecords());
        }
    }
}