using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DNPHandin1.Data;
using DNPHandin1.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdultsController : ControllerBase
    {
        IAdultsService adultService;

        public AdultsController(IAdultsService adultsService) 
        {
            this.adultService = adultsService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try
            {
                IList<Adult> adults = await adultService.GetAdults();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return StatusCode(500,e.Message);

            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> PostAdult([FromBody] Adult adult)
        {
            try
            {
                Adult adult1 = await adultService.AddAdult(adult);
                return Ok(adult1);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return StatusCode(409, e.Message);

            }
        }

        [HttpDelete("{id}")]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await adultService.RemoveAdult(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(204, e.Message);
            }
        }
    }
}
