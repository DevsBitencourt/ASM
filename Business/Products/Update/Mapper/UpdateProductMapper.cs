using Business.Models.Products.Update;
using Repository.Models.Products;

namespace Business.Products.Update.Mapper
{
    /// <summary>
    /// Classe responsavel por realizar o mapeamento dos dados de prdutos
    /// </summary>
    internal class UpdateProductMapper
    {
        /// <summary>
        /// Mapeamento da dto de entrada para a model de persistencia
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UpdateProductDto MapResponse(ProductModel model)
        {
            return new()
            {
                Id = model.Id,
                Name = model.Name,
                Amount = model.Amount,
                Price = model.Price
            };
        }

        /// <summary>
        /// Mapeamento da model de persistencia para a dto de saída
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ProductModel MapRequest(UpdateProductDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Amount = dto.Amount,
                Price = dto.Price
            };
        }
    }
}
