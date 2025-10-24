using Business.Contract.Products;
using Business.Models;
using Business.Shared.Exceptions;
using Repository.Contract.Products;

namespace Business.Products.Delete
{
    /// <summary>
    /// Camada de negócios responsavel pela exclusao de produto
    /// </summary>
    public class DeleteProductBusiness : IDeleteProductBusiness
    {
        private readonly IDeleteProductRepository repository;

        public DeleteProductBusiness(IDeleteProductRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Excluir produtos do sistema
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
