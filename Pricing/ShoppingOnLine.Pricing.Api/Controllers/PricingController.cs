using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnLine.Pricing.Api.Model;

namespace ShoppingOnLine.Pricing.Api.Controllers
{
    [Route("api/[controller]")]
    public class PricingController : Controller
    {
        // GET api/pricing
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/pricing/5
        [HttpGet("{id}")]
        public string Get(IEnumerable<int> id)
        {
            return "value";
        }

        // POST api/pricing
        [HttpPost]
        public void Post([FromBody]InsertPrice value)
        {
        }

        // PUT api/pricing/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]UpdatePrice value)
        {
        }

        // DELETE api/pricing/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
