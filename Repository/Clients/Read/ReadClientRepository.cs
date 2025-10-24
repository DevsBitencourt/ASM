using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Clients;
using Repository.Models.Clients;
using Repository.SQLServer;

namespace Repository.Clients.Read
{

    /// <summary>
    /// Classe responsavel por consultar clientes no banco de dados
    /// </summary>
    public class ReadClientRepository : ConnectionSql, IReadClientsRepository
    {
        public ReadClientRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<ClientModel>> FindAllAsync()
        {
            try
            {
                await using var connection = CreateConnection();
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
                await using var connection = CreateConnection();
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
                await using var connection = CreateConnection();
                return await connection.QueryAsync<ClientModel>(ReadClientQuery.FindByName(), new { NAME = name });
            }
            catch (Exception)
            {
                return [];
            }
        }

        public async Task<int?> TotalRecordsAsync()
        {
            return await this.TotalRecords(ReadClientQuery.TotalRecords());
        }
    }
}
