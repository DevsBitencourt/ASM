using Business.Contract.OrdersItems;
using Business.Models;
using Business.Models.Orders.Create;
using Business.Models.OrdersItems;
using Microsoft.AspNetCore.Mvc;

namespace XPedidos.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersItemsController : ControllerBase
    {
        private readonly ICreateOrderItemBusiness createBusiness;
        private readonly IUpdateOrderItemBusiness updateBusiness;
        private readonly IDeleteOrderItemBusiness deleteBusiness;

        public OrdersItemsController(ICreateOrderItemBusiness createBusiness, IUpdateOrderItemBusiness updateBusiness, IDeleteOrderItemBusiness deleteBusiness)
        {
            this.createBusiness = createBusiness;
            this.updateBusiness = updateBusiness;
            this.deleteBusiness = deleteBusiness;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBase<CreateOrderRespondeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatedAsync(OrderItemDto model)
        {
            var response = await createBusiness.CreateAsync(model);

            if (response?.Data?.IdOrder > 0)
                return Ok(response);
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(OrderItemDto model)
        {
            var response = await updateBusiness.UpdateAsync(model);

            if (response.Data is not null)
                return NoContent();
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("id/idProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletedAsync(int id, int idProduct)
        {
            var response = await deleteBusiness.DeleteAsync(id, idProduct);

            if (response.Data)
                return NoContent();
            else
            {
                return BadRequest(response);
            }
        }

    }
}
