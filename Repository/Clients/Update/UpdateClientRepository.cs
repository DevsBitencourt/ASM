using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Clients;
using Repository.Models.Clients;
using Repository.SQLServer;

namespace Repository.Clients.Update
{
    public class UpdateClientRepository : ConnectionSql, IUpdateClientRepository
    {
        public UpdateClientRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ClientModel?> UpdateAsync(ClientModel entity)
        {
            try
            {
                await using var connection = new SqlConnection(ConnectioString);
                var response = await connection.ExecuteAsync(UpdateClientQuery.Update(), new { id = entity.IdClients, name = entity.Name, document = entity.Document, email = entity.Email, telephone = entity.Telephone });

                return response > 0 ? entity : null;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
