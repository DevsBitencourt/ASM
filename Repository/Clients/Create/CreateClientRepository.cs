using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Clients;
using Repository.Models.Clients;
using Repository.SQLServer;

namespace Repository.Clients.Create
{
    public class CreateClientRepository : ConnectionSql, ICreateClientRepository
    {
        public CreateClientRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ClientModel?> CreateAsync(ClientModel entity)
        {
            try
            {
                entity.IdClients = await this.SequenceAsync("SEQUENCE_CLIENTS");
                await using var connection = new SqlConnection(ConnectioString);
                var response = await connection.ExecuteAsync(CreateClientQuery.Create(), new { id = entity.IdClients, name = entity.Name, document = entity.Document, email = entity.Email, telephone = entity.Telephone });
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
