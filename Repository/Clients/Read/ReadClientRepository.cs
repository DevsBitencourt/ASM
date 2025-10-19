using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Clients;
using Repository.Models.Clients;
using Repository.SQLServer;

namespace Repository.Clients.Read
{
    public class ReadClientRepository : ConnectionSql, IReadClientsRepository
    {
        public ReadClientRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<ClientModel>> FindAllAsync()
        {
            try
            {
                await using var connection = new SqlConnection(ConnectioString);
                return await connection.QueryAsync<ClientModel>(ReadClientQuery.FindAll());
            }
            catch (Exception)
            {
                return [];
            }
        }

        public async Task<ClientModel> FindByIdAsync(int id)
        {
            try
            {
                await using var connection = new SqlConnection(ConnectioString);
                return await connection.QueryFirstAsync<ClientModel>(ReadClientQuery.FindById(), new { ID_CLIENTS = id });
            }
            catch (Exception)
            {
                return new ClientModel();
            }
        }

        public async Task<IEnumerable<ClientModel>> FindByNameAsync(string name)
        {
            try
            {
                await using var connection = new SqlConnection(ConnectioString);
                return await connection.QueryAsync<ClientModel>(ReadClientQuery.FindByName(), new { NAME = name });
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
                return await connection.ExecuteScalarAsync<int>(ReadClientQuery.TotalRecords());
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
