using Business.Contract.Clients;
using Business.Models;
using Repository.Contract.Clients;

namespace Business.Clients.Delete
{
    public class DeleteClientBusiness : IDeleteClientBusiness
    {
        private readonly IDeleteClientRepository repository;

        public DeleteClientBusiness(IDeleteClientRepository repository)
        {
            this.repository = repository;
        }

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
