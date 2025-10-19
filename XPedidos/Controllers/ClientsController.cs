using Business.Contract.Clients;
using Business.Contract.Clients.Update;
using Business.Models;
using Business.Models.Clients.Create;
using Business.Models.Clients.Read;
using Business.Models.Clients.Update;
using Microsoft.AspNetCore.Mvc;

namespace XPedidos.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ICreateClientBusiness createBusiness;
        private readonly IReadClientBusiness readBusiness;
        private readonly IUpdateClientBusiness updateBusiness;
        private readonly IDeleteClientBusiness deleteBusiness;

        public ClientsController(ICreateClientBusiness createBusiness, IReadClientBusiness readBusiness, IUpdateClientBusiness updateBusiness, IDeleteClientBusiness deleteBusiness)
        {
            this.createBusiness = createBusiness;
            this.readBusiness = readBusiness;
            this.updateBusiness = updateBusiness;
            this.deleteBusiness = deleteBusiness;
        }

        #region Methods Get

        [HttpGet]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<ReadClientDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFindAllAsync()
        {
            var response = await readBusiness.FindAllAsync();
            return Ok(response);
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(ResponseBase<ReadClientDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFindByIdAsync(int id)
        {
            var response = await readBusiness.FindByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("name")]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<ReadClientDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFindByNameAsync(string name)
        {
            var response = await readBusiness.FindByNameAsync(name);
            return Ok(response);
        }

        [HttpGet("totalRecords")]
        [ProducesResponseType(typeof(ResponseBase<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> TotalRecordsAsync()
        {
            var response = await readBusiness.TotalRecordsAsync();
            return Ok(response);
        }

        #endregion

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBase<CreateClientResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatedAsync(CreateClientDto model)
        {
            var response = await createBusiness.CreateAsync(model);

            if (response.Data.Id > 0)
                return Ok(response);
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(UpdateClientDto model)
        {
            var response = await updateBusiness.UpdateAsync(model);

            if (response.Data is not null)
                return NoContent();
            else
            {
                return BadRequest(response);
            }
        }

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
