using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Clients;
using Repository.SQLServer;

namespace Repository.Clients.Delete
{
    /// <summary>
    /// Classe responsavel por persistir a exclusão de clientes
    /// </summary>
    public class DeleteClientRepository : ConnectionSql, IDeleteClientRepository
    {
        public DeleteClientRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await using var connection = CreateConnection();
                var response = await connection.ExecuteAsync(DeleteClientQuery.DeleteById(), new { id });
                return response > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
