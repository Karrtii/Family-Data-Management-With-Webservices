using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPHandin1.Data;
using DNPHandin1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService inMemoryUserService;

        public UsersController(IUserService inMemoryUserService)
        {
            this.inMemoryUserService = inMemoryUserService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                User user = await inMemoryUserService.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return StatusCode(404, e.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] User newUser)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            try
            {
                await inMemoryUserService.AddUser(newUser);
                return Ok();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return StatusCode(409, e.Message);
            }
        }
    }
}
