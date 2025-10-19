using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Clients;
using Repository.SQLServer;

namespace Repository.Clients.Delete
{
    public class DeleteClientRepository : ConnectionSql, IDeleteClientRepository
    {
        public DeleteClientRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await using var connection = new SqlConnection(ConnectioString);
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
