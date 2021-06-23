using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Controllers
{
    //Controller take care of Http Request and returns data to the client
    [ApiController]
    [Route("api[controller]")]
    public class BasketItemController : Controller
    {
        private readonly IBasketItemService _basketItemService;


        public BasketItemController(IBasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
        }

        //GET ALL
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var basketItems = await _basketItemService.GetAll();
                if (basketItems == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Unexpected null returned from service");
                }
                else if (basketItems.Count == 0)
                {
                    // no  data exist, but evertything is still ok, return code 204
                    return NoContent();
                }
                // we got data! return with code 200
                return Ok(basketItems);

            }
            catch (Exception ex)
            {
                //handle any other exeptons raised by sending code 500
                return Problem(ex.Message); 
            }
        }

        //GET
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BasketItem))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Get([FromRoute] int id)
        {

            try
            {
                var basketItem = await _basketItemService.Get(id);
                if (basketItem == null)
                {
                    // no  data exist, but evertything is still ok, return code 204
                    return NotFound();
                }
                // we got data! return with code 200
                return Ok(basketItem);

            }
            catch (Exception ex)
            {
                //handle any other exception raised by sending code 500
                return Problem(ex.Message);
            }
        }

        //POST
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Create(BasketItem basketitem)
        {
            try
            {
                if (basketitem == null)
                {
                    return BadRequest("A Error Occured");
                }
                var newItemBasket = await _basketItemService.Create(basketitem);

                // we got data! return with code 200
                return Ok(newItemBasket);
            }
            catch (Exception ex)
            {
                //handle any other exception raised by sending code 500
                return Problem(ex.Message);
            }
        }

        //PUT
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BasketItem basketItem )
        {
            try
            {
                var editBasketItem = await _basketItemService.Update(id, basketItem);
                if (editBasketItem == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Update edit failed");
                }
                // we got data! return with code 200
                return Ok(editBasketItem);
            }
            catch (Exception ex)
            {
                //handle any other exception raised by sending code 500
                return Problem(ex.Message);
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var basketItem = await _basketItemService.Delete(id);
                // we got data! return with code 200
                return Ok(basketItem);
            }
            catch (Exception ex)
            {
                //handle any other exception raised by sending code 500
                return Problem(ex.Message);
            }
        }

        //Get by Basket
        [HttpGet("byBasket/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByBasket([FromRoute] int id)
        {
            try
            {
                var basketItems = await _basketItemService.GetByBasket(id);
                if (basketItems == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Unexpected null returned from service");
                }
                else if (basketItems.Count == 0)
                {
                    // no  data exist, but evertything is still ok, return code 204
                    return NoContent();
                }
                // we got data! return with code 200
                return Ok(basketItems);

            }
            catch (Exception ex)
            {
                //handle any other exeptons raised by sending code 500
                return Problem(ex.Message);
            }
        }
    }
}
