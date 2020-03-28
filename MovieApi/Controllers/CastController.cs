using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        // GET: api/Cast
        [HttpGet]
        public IEnumerable<string> GetCasts()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cast/5
        [HttpGet("{id}", Name = "GetCast")]
        public string GetCast(int id)
        {
            return "value";
        }

        // POST: api/Cast
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cast/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
