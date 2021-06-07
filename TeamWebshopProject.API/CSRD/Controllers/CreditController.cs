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
    [Route("api/credit")]
    public class CreditController : ControllerBase
    {
        private readonly ICreditService _creditService;

        public CreditController(ICreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var credits = await _creditService.GetAll();

                if ( credits == null )
                {
                    return Problem("Cannot be null, get some data in there");
                }
                else if ( credits.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(credits);
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Credit))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var credit = await _creditService.Get(id);

                if ( credit == null )
                {
                    return NotFound();
                }
                else
                {
                    return Ok(credit);
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
        public async Task<IActionResult> Create(Credit credit)
        {
            try
            {
                if ( credit == null )
                {
                    return BadRequest("Credit fail");
                }

                var newCredit = await _creditService.Create(credit);
                return Ok(newCredit);
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
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Credit credit)
        {
            try
            {
                var editCredit = await _creditService.Update(id, credit);

                if ( editCredit == null )
                {
                    return Problem("Edit failed");
                }
                else
                {
                    return Ok(editCredit);
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
                var deleteCredit = await _creditService.Delete(id);

                return Ok(deleteCredit);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
