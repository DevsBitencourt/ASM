using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Contract.Products;
using Repository.Models.Products;
using Repository.SQLServer;

namespace Repository.Products.Create
{
    public class CreateProductRepository : ConnectionSql, ICreateProductRepository
    {
        public CreateProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ProductModel?> CreateAsync(ProductModel entity)
        {
            try
            {
                entity.Id = await this.SequenceAsync("SEQUENCE_PRODUCTS");
                await using var connection = new SqlConnection(ConnectioString);
                var response = await connection.ExecuteAsync(CreateProductQuery.Create(), new { id = entity.Id, name = entity.Name, amount = entity.Amount, price = entity.Price });
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
