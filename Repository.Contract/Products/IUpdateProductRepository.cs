using Repository.Models.Products;

namespace Repository.Contract.Products
{
    public interface IUpdateProductRepository
    {
        Task<ProductModel> UpdateAsync(ProductModel model);

        Task<ProductModel?> StockMovementAsync(ProductModel model);
    }
}
