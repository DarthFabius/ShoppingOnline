using System.Collections.Generic;
using ShoppingOnLine.Marketing.Api.Model;
using ShoppingOnLine.Marketing.Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingOnLine.Marketing.Api.Controllers
{
    [Route("api/[controller]")]
    public class MarketingController : Controller
    {
        MarketingApiRepository _repository;

        public MarketingController(MarketingApiRepository repository)
        {
            _repository = repository;
        }

        // GET api/Marketing
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Marketing/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Marketing/insert
        [HttpPost("insert")]
        public void Insert([FromBody]object value)
        {

        }

        [HttpPost("update")]
        public IActionResult Update([FromBody]object value)
        {
            return Ok();
        }

        // DELETE api/Marketing/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
