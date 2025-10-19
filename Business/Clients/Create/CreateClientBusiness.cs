using Business.Clients.Create.Mapper;
using Business.Contract.Clients;
using Business.Models;
using Business.Models.Clients.Create;
using Repository.Contract.Clients;

namespace Business.Clients.Create
{
    public class CreateClientBusiness : ICreateClientBusiness
    {
        private readonly ICreateClientRepository repository;

        public CreateClientBusiness(ICreateClientRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseBase<CreateClientResponseDto>> CreateAsync(CreateClientDto entity)
        {
            var mapperInput = CreateClientMapper.MapRequest(entity);

            var response = await repository.CreateAsync(mapperInput);


            if (response != null)
            {
                var mepperOutput = CreateClientMapper.MapResponse(response);

                return new() { Data = mepperOutput };
            }
            else
            {
                return new()
                {
                    Errors = "Não foi possivel criar o usuario"
                };
            }
        }
    }
}
