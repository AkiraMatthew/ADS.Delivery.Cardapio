using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ADS.Delivery.API.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ADSDApiController : ControllerBase
    {
        // GET: api/<ADSDApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ADSDApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ADSDApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ADSDApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ADSDApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
