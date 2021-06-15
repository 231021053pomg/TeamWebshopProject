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
    [Route("api/basket")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var baskets = await _basketService.GetAll();

                if ( baskets == null )
                {
                    return Problem("Cannot be null, get some data in there");
                }
                else if ( baskets.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(baskets);
                }

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Basket))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var basket = await _basketService.Get(id);

                if ( basket == null )
                {
                    return Problem("Cannot be null, get some data in there");
                }
                else if ( basket == null )
                {
                    return NotFound();
                }
                else
                {
                    return Ok(basket);
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
        public async Task<IActionResult> Create(Basket basket)
        {
            try
            {
                if ( basket == null )
                {
                    return BadRequest("Basket fail");
                }
                else
                {
                    var newBasket = await _basketService.Create(basket);

                    return Ok(newBasket);
                }
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
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Basket basket)
        {
            try
            {
                var editBasket = await _basketService.Update(id, basket);

                if ( editBasket == null )
                {
                    return Problem("Edit failed");
                }
                else
                {
                    return Ok(editBasket);
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
                var deleteBasket = await _basketService.Delete(id);

                return Ok(deleteBasket);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
