using Microsoft.Extensions.Configuration;
using Repository.Contract.Products;
using Repository.Models.Products;
using Repository.SQLServer;
using static Dapper.SqlMapper;

namespace Repository.Products.Update
{
    /// <summary>
    /// Classe responsavel por persistir a atualizacao de produtos
    /// </summary>
    public class UpdateProductRepository : ConnectionSql, IUpdateProductRepository
    {
        public UpdateProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ProductModel> UpdateAsync(ProductModel model)
        {
            try
            {
                await using var connection = CreateConnection();
                var response = await connection.ExecuteAsync(UpdateProductQuery.Command(), new { id = model.Id, name = model.Name, amount = model.Amount, price = model.Price });
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ProductModel?> StockMovementAsync(ProductModel model)
        {
            try
            {
                await using var connection = CreateConnection();
                var response = await connection.ExecuteAsync(UpdateProductQuery.StockMovementCommand(), new { id = model.Id, amount = model.Amount });
                return model;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
