using Business.Contract.Products;
using Business.Models;
using Business.Models.Products.Create;
using Business.Models.Products.Read;
using Business.Models.Products.Update;
using Microsoft.AspNetCore.Mvc;

namespace XPedidos.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ICreateProductBusiness createBusiness;
        private readonly IReadProductBusiness readBusiness;
        private readonly IUpdateProductBusiness updateBusiness;
        private readonly IDeleteProductBusiness deleteBusiness;

        public ProductsController(ICreateProductBusiness createBusiness, IReadProductBusiness readBusiness, IUpdateProductBusiness updateBusiness, IDeleteProductBusiness deleteBusiness)
        {
            this.createBusiness = createBusiness;
            this.readBusiness = readBusiness;
            this.updateBusiness = updateBusiness;
            this.deleteBusiness = deleteBusiness;
        }

        #region Methods Get

        [HttpGet]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<ReadProductResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFindAllAsync()
        {
            var response = await readBusiness.FindAllAsync();
            return Ok(response);
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(ResponseBase<ReadProductResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFindByIdAsync(int id)
        {
            var response = await readBusiness.FindByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("name")]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<ReadProductResponseDto>>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(ResponseBase<CreateProductResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatedAsync(CreateProductsRequestDto model)
        {
            var response = await createBusiness.CreateAsync(model);

            if (response?.Data?.Id > 0)
                return Ok(response);
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(UpdateProductDto model)
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
