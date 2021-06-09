using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;
using TeamWebshopProject.API.CSRD.Services.Interfaces;

namespace TeamWebshopProject.API.CSRD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orderitems = await _orderItemService.GetAll();

                if ( orderitems == null )
                {
                    return Problem("Unexpected null");
                }
                else if ( orderitems.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(orderitems);
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderItem))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var orderitem = await _orderItemService.Get(id);

                if ( orderitem == null )
                {
                    return NotFound():
                }
                else
                {
                    return Ok(orderitem);
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(OrderItem orderItem)
        {
            try
            {
                if ( orderItem == null )
                {
                    return BadRequest("Order fail");
                }

                var newOrderItem = await _orderItemService.Create(orderItem);
                return Ok(newOrderItem);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message)
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] OrderItem orderItem)
        {
            try
            {
                var editOrderitem = await _orderItemService.Update(id, orderItem);

                if ( editOrderitem == null )
                {
                    return Problem("Edit failed");
                }
                else
                {
                    return Ok(editOrderitem);
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var orderItem = await _orderItemService.Delete(id);

                return Ok(orderItem);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
