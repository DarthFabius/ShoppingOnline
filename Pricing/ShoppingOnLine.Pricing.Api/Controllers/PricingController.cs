using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnLine.Pricing.Api.Model;
using ShoppingOnLine.Pricing.Api.Repository;

namespace ShoppingOnLine.Pricing.Api.Controllers
{
    [Route("api/[controller]")]
    public class PricingController : Controller
    {
        private PricingApiRepository _repository;
        public PricingController(PricingApiRepository repository)
        {
            _repository = repository;
        }

        // GET api/pricing
        [HttpGet]
        public IEnumerable<DetailPrice> Get()
        {
            return _repository.GetPrice();
        }

        // GET api/pricing/5
        [HttpGet("{id}")]
        public IEnumerable<DetailPrice> Get(int id)
        {
            return _repository.GetPrice(new List<int>() { id });
        }

        // POST api/pricing
        [HttpPost]
        public void Post([FromBody]InsertPrice value)
        {
            _repository.InsertPricing(value);
        }

        // PUT api/pricing/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]UpdatePrice value)
        {
            _repository.UpdatePrice(value);
        }

        // DELETE api/pricing/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeletePrice(id);
        }
    }
}
