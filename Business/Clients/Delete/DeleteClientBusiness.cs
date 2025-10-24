using Business.Contract.Clients;
using Business.Models;
using Repository.Contract.Clients;

namespace Business.Clients.Delete
{
    /// <summary>
    /// Camada de negócios responsavel pela exclusão de clientes
    /// </summary>
    public class DeleteClientBusiness : IDeleteClientBusiness
    {
        private readonly IDeleteClientRepository repository;

        public DeleteClientBusiness(IDeleteClientRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Deleta o cliente com base no seu identificador único
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseBase<bool>> DeleteAsync(int id)
        {
            var response = await repository.DeleteAsync(id);
            return new()
            {
                Data = response
            };
        }
    }
}
