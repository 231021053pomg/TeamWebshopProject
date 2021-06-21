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
     
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;


        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
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
                var items = await _itemService.GetAll();
                if (items == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Unexpected null returned from service");
                }
                else if (items.Count == 0)
                {
                    // no  data exist, but evertything is still ok, return code 204
                    return NoContent();
                }
                //we got data! return code 200
                return Ok(items);
            }
            catch (Exception ex)
            {
                //handle any other exeptons raised by sending code 500
                return Problem(ex.Message);
            }
        }
        //GET
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var item = await _itemService.Get(id);
                if (item == null)
                {
                    // no  data exist, but evertything is still ok, return code 204
                    return NotFound();
                }
                // we got data! return with code 200
                return Ok(item);
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

        public async Task<IActionResult> Create(Item item)
        {
            try
            {
              
                if (item == null)
                {
                    return BadRequest("A Error Occured");
                }
                var newItem = await _itemService.Create(item);

                // we got data! return with code 200
                return Ok(newItem);
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
        
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Item item)
        {
            try
            {
                var editItem = await _itemService.Update(id, item);
                if (editItem == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Update edit failed");
                }
                // we got data! return with code 200
                return Ok(editItem);
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
                var item = await _itemService.Delete(id);
                // we got data! return with code 200
                return Ok(item);
            }
            catch (Exception ex)
            {

                //handle any other exception raised by sending code 500
                return Problem(ex.Message);
            }
        }
    }
}
