using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Products;
using Repository.Models.Products;
using Repository.SQLServer;
using static Dapper.SqlMapper;

namespace Repository.Products.Read
{
    /// <summary>
    /// Classe responsavel por persistir pesquisa de produtos
    /// </summary>
    public class ReadProductRepository : ConnectionSql, IReadProductRepository
    {
        public ReadProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<ProductModel>> FindAllAsync()
        {
            try
            {
                await using var connection = CreateConnection();
                return await connection.QueryAsync<ProductModel>(ReadProductQuery.FindAll());
            }
            catch (Exception)
            {
                return [];
            }
        }

        public async Task<ProductModel?> FindByIdAsync(int id)
        {
            try
            {

                await using var connection = CreateConnection();
                return await connection.QueryFirstAsync<ProductModel>(ReadProductQuery.FindById(), new { id });
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProductModel>> FindByNameAsync(string name)
        {
            try
            {

                await using var connection = CreateConnection();
                return await connection.QueryAsync<ProductModel>(ReadProductQuery.FindByName(), new { name });
            }
            catch (Exception)
            {
                return [];
            }
        }

        public async Task<int?> TotalRecordsAsync()
        {
            return await this.TotalRecords(ReadProductQuery.TotalRecords());
        }

    }
}
