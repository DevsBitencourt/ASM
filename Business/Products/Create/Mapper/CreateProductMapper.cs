using Business.Models.Products.Create;
using Repository.Models.Products;

namespace Business.Products.Create.Mapper
{
    internal class CreateProductMapper
    {
        public static ProductModel MapRequest(CreateProductsRequestDto dto)
        {
            return new()
            {
                Name = dto.Name,
                Amount = dto.Amount,
                Price = dto.Price
            };
        }

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
