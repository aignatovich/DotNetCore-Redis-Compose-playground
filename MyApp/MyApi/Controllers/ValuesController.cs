using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace MyApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDistributedCache cache;

        public ValuesController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<string>> Get(string key) 
            => await cache.GetStringAsync(key);

        [HttpPost("{key}/{value}")]
        public async Task Post(string key, string value) 
            => await cache.SetStringAsync(key, value);
    }
}
