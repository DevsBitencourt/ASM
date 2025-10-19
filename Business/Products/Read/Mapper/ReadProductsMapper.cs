using Business.Models.Products.Read;
using Repository.Models.Products;

namespace Business.Products.Read.Mapper
{
    internal class ReadProductsMapper
    {
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

        public static IEnumerable<ReadProductResponseDto> MapResponse(IEnumerable<ProductModel> model)
        {
            return model.Select(m => MapResponse(m));
        }
    }
}
