using Business.Models.Products.Read;
using Repository.Models.Products;

namespace Business.Products.Read.Mapper
{
    /// <summary>
    /// Classe responsavel por realizar o mapeamento dos dados de prdutos
    /// </summary>
    internal class ReadProductsMapper
    {
        /// <summary>
        /// Mapeamento da model de persistencia para a dto de saída
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ReadProductResponseDto MapResponse(ProductModel model)
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
        /// <param name="model"></param>
        /// <returns></returns>
        public static IEnumerable<ReadProductResponseDto> MapResponse(IEnumerable<ProductModel> model)
        {
            return model.Select(m => MapResponse(m));
        }
    }
}
