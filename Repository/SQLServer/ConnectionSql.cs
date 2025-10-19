using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Dapper.SqlMapper;

namespace Repository.SQLServer
{
    public abstract class ConnectionSql
    {
        protected readonly string ConnectioString;

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
    }
}
