using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnLine.ShoppingCart.Api.Model;

namespace ShoppingOnLine.ShoppingCart.Api.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartController : Controller
    {
        private Cart _cart;
        
        public ShoppingCartController(Cart cart)
        {
            _cart = cart;
        }

        // GET api/ShoppingCart
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return new List<Cart>() { _cart };
        }

        // GET api/ShoppingCart/5
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            return _cart;
        }

        // POST api/ShoppingCart
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/ShoppingCart/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CartItem value)
        {
            if (_cart.Items.Any(p=>p.ProductId.Equals(value.ProductId)))
            {
                var item = _cart.Items.Where(p => p.ProductId.Equals(value.ProductId)).Single();
                item.NumberOfProduct+= value.NumberOfProduct;
            }
            else
            {
                _cart.Items.Add(new CartItem()
                {
                    DateOfAdd = value.DateOfAdd,
                    NumberOfProduct = value.NumberOfProduct,
                    ProductId = value.ProductId
                });
            }
        }

        // DELETE api/ShoppingCart/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
