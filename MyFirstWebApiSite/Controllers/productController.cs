using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly IproductService _productService;

        public productController(IproductService productService)
        {
            _productService = productService;
        }
        // GET: api/<productController>
        [HttpGet]
        public async Task<IEnumerable<Product>> getProductAsync(int? position, int? skip, string? name, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            return await _productService.getProductAsync(position, skip, name, minPrice, maxPrice,  categoryIds);
        }

        // GET api/<productController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<productController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<productController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<productController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
