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
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var logins = await _loginService.GetAll();

                if ( logins == null )
                {
                    return Problem("Unexpected null");
                }
                else if ( logins.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(logins);
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Login))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var login = await _loginService.Get(id);

                if ( login == null )
                {
                    return NotFound();
                }
                else
                {
                    return Ok(login);
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
        public async Task<IActionResult> Create(Login login)
        {
            try
            {
                if ( login == null )
                {
                    return BadRequest("Login fail");
                }

                var newLogin = await _loginService.Create(login);
                return Ok(newLogin);
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
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Login login)
        {
            try
            {
                var editLogin = await _loginService.Update(id, login);

                if ( editLogin == null )
                {
                    return Problem("Login failed");
                }
                else
                {
                    return Ok(editLogin);
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
                var login = await _loginService.Delete(id);

                return Ok(login);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
