using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDistributedCache cache;

        public ValuesController(IDistributedCache cache)
        {
            this.cache = cache;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{key}")]
        public ActionResult<string> Get(string key)
        {
            return cache.GetString(key);
        }

        // POST api/values
        [HttpPost("{key}/{value}")]
        public void Post([FromQuery] string key, [FromQuery] string value)
        {
            cache.Set("qwe", Encoding.UTF8.GetBytes("qwe"));
        }

        // PUT api/values/5
        [HttpPut("{key}/{value}")]
        public void Put(string key, string value)
        {
            cache.Set(key, Encoding.UTF8.GetBytes(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
