using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Clients;
using Repository.Models.Clients;
using Repository.SQLServer;

namespace Repository.Clients.Create
{
    /// <summary>
    /// Classe responsavel por persistir a inclusao de clientes
    /// </summary>
    public class CreateClientRepository : ConnectionSql, ICreateClientRepository
    {
        public CreateClientRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Adicionar cliente
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ClientModel?> CreateAsync(ClientModel entity)
        {
            try
            {
                entity.IdClients = await this.SequenceAsync("SEQUENCE_CLIENTS");
                await using var connection = CreateConnection();
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
