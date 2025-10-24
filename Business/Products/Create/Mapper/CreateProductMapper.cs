using Business.Models.Products.Create;
using Repository.Models.Products;

namespace Business.Products.Create.Mapper
{
    /// <summary>
    /// Classe responsavel por realizar o mapeamento dos dados de prdutos
    /// </summary>
    internal class CreateProductMapper
    {
        /// <summary>
        /// Mapeamento da dto de entrada para a model de persistencia
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static ProductModel MapRequest(CreateProductsRequestDto dto)
        {
            return new()
            {
                Name = dto.Name,
                Amount = dto.Amount,
                Price = dto.Price
            };
        }

        /// <summary>
        /// Mapeamento da model de persistencia para a dto de saída
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static CreateProductResponseDto MapResponse(ProductModel model)
        {
            return new()
            {
                Id = model.Id,
                Name = model.Name,
                Amount = model.Amount,
                Price = model.Price
            };
        }
    }
}
