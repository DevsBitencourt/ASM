using Business.Models.Products.Update;
using Repository.Models.Products;

namespace Business.Products.Update.Mapper
{
    internal class UpdateProductMapper
    {
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
