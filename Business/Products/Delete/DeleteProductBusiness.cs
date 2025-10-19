using Business.Contract.Products;
using Business.Models;
using Business.Shared.Exceptions;
using Repository.Contract.Products;

namespace Business.Products.Delete
{
    public class DeleteProductBusiness : IDeleteProductBusiness
    {
        private readonly IDeleteProductRepository repository;

        public DeleteProductBusiness(IDeleteProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<bool>> DeleteAsync(int id)
        {
            try
            {
                var response = await repository.DeleteAsync(id);
                return new() { Data = response };
            }
            catch (ForeignKeyException ef)
            {
                return new() { Errors = new List<string>() { ef.Message } };
            }
        }
    }
}
