using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Orders;
using Repository.Models.Orders.Read;
using Repository.SQLServer;

namespace Repository.Orders.Read
{
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

                await using var connection = new SqlConnection(ConnectioString);

                var response = await connection.QueryAsync<ReadOrderModel, ReadOrderItemModel, ReadOrderModel>(ReadOrderQuery.FindAll(),
                    (order, orderItem) =>
                    {
                        if (!orderDictionary.TryGetValue(order.Id, out ReadOrderModel orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.Items = new List<ReadOrderItemModel>();
                            orderDictionary.Add(orderEntry.Id, orderEntry);
                        }

                        orderEntry?.Items?.Add(orderItem);

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
                await using var connection = new SqlConnection(ConnectioString);
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
                await using var connection = new SqlConnection(ConnectioString);
                return await connection.QueryAsync<ReadOrderModel>(ReadOrderQuery.FindByName(), new { name });
            }
            catch (Exception)
            {
                return [];
            }
        }

        public async Task<int?> TotalRecordsAsync()
        {
            try
            {
                await using var connection = new SqlConnection(ConnectioString);
                return await connection.ExecuteScalarAsync<int>(ReadOrderQuery.TotalRecords());
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
