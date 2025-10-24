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

        /// <summary>
        /// Busca lista de produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<ReadProductResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFindAllAsync()
        {
            var response = await readBusiness.FindAllAsync();
            return Ok(response);
        }

        /// <summary>
        /// Busca produto com base no seu identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        [ProducesResponseType(typeof(ResponseBase<ReadProductResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFindByIdAsync(int id)
        {
            var response = await readBusiness.FindByIdAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Busca produtos que contenham o nome informado
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name")]
        [ProducesResponseType(typeof(ResponseBase<IEnumerable<ReadProductResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFindByNameAsync(string name)
        {
            var response = await readBusiness.FindByNameAsync(name);
            return Ok(response);
        }

        /// <summary>
        /// Captura quantidade de produtos cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("totalRecords")]
        [ProducesResponseType(typeof(ResponseBase<int>), StatusCodes.Status200OK)]
        public async Task<IActionResult> TotalRecordsAsync()
        {
            var response = await readBusiness.TotalRecordsAsync();
            return Ok(response);
        }

        #endregion

        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Atualiza produto existente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete item com base no seu identificador
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
