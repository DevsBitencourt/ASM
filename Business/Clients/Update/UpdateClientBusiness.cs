using Business.Contract.Clients.Update;
using Business.Models;
using Business.Models.Clients.Update;
using Repository.Contract.Clients;

namespace Business.Clients.Update
{
    public class UpdateClientBusiness : IUpdateClientBusiness
    {

        private readonly IUpdateClientRepository repository;

        public UpdateClientBusiness(IUpdateClientRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<UpdateClientDto>> UpdateAsync(UpdateClientDto entity)
        {
            var mapperInput = Mapper.UpdateClientMapper.MapRequest(entity);

            var response = await repository.UpdateAsync(mapperInput);

            return new() { Data = Mapper.UpdateClientMapper.MapResponse(response) };
        }
    }
}
