using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnLine.Marketing.Api.Model;
using ShoppingOnLine.Marketing.Api.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingOnLine.Marketing.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private MarketingApiRepository _repository;
        public ProductController(MarketingApiRepository repository)
        {
            _repository = repository;
        }
        // GET: /<controller>/
        public IEnumerable<ProductDetail> Get()
        {
            return _repository.getAllProduct();
        }
    }
}
