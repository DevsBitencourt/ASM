using Business.Shared.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Products;
using Repository.SQLServer;
using static Dapper.SqlMapper;

namespace Repository.Products.Delete
{
    /// <summary>
    /// Classe responsavel por persistir a exclusao de produtos
    /// </summary>
    public class DeleteProductRepository : ConnectionSql, IDeleteProductRepository
    {
        public DeleteProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await using var connection = CreateConnection();
                var response = await connection.ExecuteAsync(DeleteProductQuery.Delete(), new { id });
                return response > 0;
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new ForeignKeyException("Não é possível excluir este registro pois existe vinculo com pedidos");
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
