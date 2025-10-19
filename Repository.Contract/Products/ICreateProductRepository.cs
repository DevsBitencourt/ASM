using Repository.Models.Products;

namespace Repository.Contract.Products
{
    public interface ICreateProductRepository
    {
        Task<ProductModel?> CreateAsync(ProductModel entity);
    }
}
