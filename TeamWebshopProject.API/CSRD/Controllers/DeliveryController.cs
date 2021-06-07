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
    [Route("api/delivery")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var deliveries = await _deliveryService.GetAll();

                if ( deliveries == null )
                {
                    return Problem("Unexpected null");
                }
                else if ( deliveries.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(deliveries);
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Delivery))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var delivery = await _deliveryService.Get(id);

                if ( delivery == null )
                {
                    return NotFound();
                }
                else
                {
                    return Ok(delivery);
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromRoute] int id, [FromBody] Delivery delivery)
        {
            try
            {
                if ( delivery == null )
                {
                    return BadRequest("Delivery fail");
                }

                var newDelivery = await _deliveryService.Create(delivery);
                return Ok(newDelivery);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Delivery delivery)
        {
            try
            {
                var editDelivery = await _deliveryService.Update(id, delivery);

                if ( editDelivery == null )
                {
                    return Problem("Edit failed");
                }
                else
                {
                    return Ok(editDelivery);
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
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var delivery = await _deliveryService.Delete(id);

                return Ok(delivery);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
