using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Clients;
using Repository.Models.Clients;
using Repository.SQLServer;

namespace Repository.Clients.Update
{

    /// <summary>
    /// Classe responsavel por persistir a alteração de clientes
    /// </summary>
    public class UpdateClientRepository : ConnectionSql, IUpdateClientRepository
    {
        public UpdateClientRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ClientModel?> UpdateAsync(ClientModel entity)
        {
            try
            {
                await using var connection = CreateConnection();
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
