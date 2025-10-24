using Business.Clients.Create.Mapper;
using Business.Contract.Clients;
using Business.Models;
using Business.Models.Clients.Create;
using Repository.Contract.Clients;

namespace Business.Clients.Create
{

    /// <summary>
    /// Camada de negócios responsavel pela criação de clientes
    /// </summary>
    public class CreateClientBusiness : ICreateClientBusiness
    {
        private readonly ICreateClientRepository repository;

        public CreateClientBusiness(ICreateClientRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Realiza a validação dos dados de cadastro do cliente e realiza a chamada de persistencia ao banco
        /// </summary>
        /// <param name="entity">Entidade com informações do cliente</param>
        /// <returns>Retorna a entidade de cliente cadastrado com o seu identificador</returns>
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
