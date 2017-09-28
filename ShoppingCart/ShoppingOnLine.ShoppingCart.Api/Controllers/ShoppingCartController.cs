using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingOnLine.ShoppingCart.Api.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartController : Controller
    {
        // GET api/ShoppingCart
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/ShoppingCart/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/ShoppingCart
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/ShoppingCart/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/ShoppingCart/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
