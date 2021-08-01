using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FourRequestsController : ControllerBase
    {
        // GET: api/<FourRequestsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FourRequestsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var x = id * 2; 
            return x.ToString();
        }

        // POST api/<FourRequestsController>
        [HttpPost]
        public PersonalDetailsResponseDTO Post([FromBody] PersonalDetailsDTO personalDetails)
        {
            var retval = new PersonalDetailsResponseDTO();
            retval.Status = "Adult";
            if (personalDetails.Age < 18)
            {
                retval.Status = "Not " + retval.Status; 
            }
            return retval;
        }

        // PUT api/<FourRequestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FourRequestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
