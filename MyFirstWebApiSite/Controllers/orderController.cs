using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {

        IorderService _orderService;

        public orderController(IorderService orderService)
        {
            _orderService = orderService;
        }


        // GET: api/<orderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<orderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<orderController>
        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder(Order order)
        {
            return await _orderService.AddOrderAsync(order);
        }

        // PUT api/<orderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<orderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
