using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Dapper.SqlMapper;

namespace Repository.SQLServer
{
    /// <summary>
    /// Classe responsavel por intermediar a persistencia com o banco de dados 
    /// </summary>
    public abstract class ConnectionSql
    {
        private readonly string ConnectioString;

        public ConnectionSql(IConfiguration configuration)
        {
            ConnectioString = configuration?.GetConnectionString("SqlConnection") ?? throw new ArgumentNullException("Connection string not found");
        }

        protected async Task<int> SequenceAsync(string sequenceName)
        {
            try
            {
                await using var connection = new SqlConnection(ConnectioString);
                return await connection.QueryFirstAsync<int>($"SELECT NEXT VALUE FOR {sequenceName}");
            }
            catch (Exception)
            {
                return 0;
            }
        }

        protected virtual SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectioString);
        }

        protected async virtual Task<int> TotalRecords(string commandSql)
        {
            try
            {
                await using var connection = CreateConnection();
                return await connection.ExecuteScalarAsync<int>(commandSql);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
