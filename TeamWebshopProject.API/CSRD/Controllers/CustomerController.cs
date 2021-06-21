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
    [Route("api/[controller]")]

    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public  CustomerController (ICustomerService customerService)
        {
            _customerService = customerService;
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
                var customerServices = await _customerService.GetAll();
                if (customerServices == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Unexpected null returned from service");
                }
                else if (customerServices.Count == 0)
                {
                    // no data exists, but everything is still ok, return code 204
                    return NoContent();
                }
                // we got data! return with code 200
                return Ok(customerServices);
            }
            catch (Exception ex)
            {
                // handle any other exeptions raised by sending code 500
                return Problem(ex.Message);
            }
        }
        //GET
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var customerService = await _customerService.Get(id);
                if (customerService == null)
                {
                    // no  data exist, but evertything is still ok, return code 204
                    return NotFound();
                }
                // we got data! return with code 200
                return Ok(customerService);
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

        public async Task<IActionResult> Create(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest("A Error Occured");
                }
                var newCustomer = await _customerService.Create(customer);

                //we got data! return with code 200
                return Ok(newCustomer);
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

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Customer customer)
        {
            try
            {
                var editCustomer = await _customerService.Update(id, customer);
                if (editCustomer == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Update edit failed");
                }
                //we got data! return with code 200
                return Ok(editCustomer);
            }
            catch (Exception ex)
            {
                //handle any other exception raised by sendin code 500
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
                var customer = await _customerService.Delete(id);
                //we got data! return with code 200
                return Ok(customer);
            }
            catch (Exception ex)
            {
                //handle any other exception raised by sendin code 500
                return Problem(ex.Message);
            }
        }
    }
}
