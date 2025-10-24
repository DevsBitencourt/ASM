using Business.Contract.Orders;
using Business.Models;
using Business.Models.Orders.Create;
using Business.Models.Orders.Read;
using Business.Models.Orders.Update;
using Microsoft.AspNetCore.Mvc;

namespace XPedidos.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ICreateOrderBusiness createBusiness;
        private readonly IReadOrderBusiness readBusiness;
        private readonly IUpdateOrderBusiness updateBusiness;
        private readonly IDeleteOrderBusiness deleteBusiness;

        public OrdersController(ICreateOrderBusiness createBusiness, IReadOrderBusiness readBusiness, IUpdateOrderBusiness updateBusiness, IDeleteOrderBusiness deleteBusiness)
        {
            this.createBusiness = createBusiness;
            this.readBusiness = readBusiness;
            this.updateBusiness = updateBusiness;
            this.deleteBusiness = deleteBusiness;
        }


        #region Methods Get

        /// <summary>
        /// Busca os pedidos cadastrados no sistema
        /// </summary>
        /// <returns>Retorna lista de pedidos cadastradas no sistema</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<ReadOrderResposeDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFindAllAsync()
        {
            var response = await readBusiness.FindAllAsync();
            return Ok(response);
        }

        /// <summary>
        /// Busca pedido com base no seu identificador unico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pedido do identificador</returns>
        [HttpGet("id")]
        [ProducesResponseType(typeof(ResponseBase<ReadOrderResposeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFindByIdAsync(int id)
        {
            var response = await readBusiness.FindByIdAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Busca pedidos no sistema cujo o nome do cliente contens o nome informado
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Lista de clientes contens nomes</returns>
        [HttpGet("name")]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<ReadOrderResposeDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFindByNameAsync(string name)
        {
            var response = await readBusiness.FindByNameAsync(name);
            return Ok(response);
        }

        /// <summary>
        /// Busca quantidade de registros de pedidos
        /// </summary>
        /// <returns>Retorna a quantidade de pedidos no sistema</returns>
        [HttpGet("totalRecords")]
        [ProducesResponseType(typeof(ResponseBase<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> TotalRecordsAsync()
        {
            var response = await readBusiness.TotalRecordsAsync();
            return Ok(response);
        }

        #endregion

        /// <summary>
        /// Criação de novos pedidos
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseBase<CreateOrderRespondeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatedAsync(CreateOrderRequestDto model)
        {
            var response = await createBusiness.CreateAsync(model);

            if (response?.Data?.Id > 0)
                return Ok(response);
            else
            {
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Atualização de pedido
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(UpdateOrderRequestDto model)
        {
            var response = await updateBusiness.UpdateAsync(model);

            if (response.Data is not null)
                return NoContent();
            else
            {
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Deleção de pedidos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletedAsync(int id)
        {
            var response = await deleteBusiness.DeleteAsync(id);

            if (response.Data)
                return NoContent();
            else
            {
                return BadRequest(response);
            }
        }
    }
}
