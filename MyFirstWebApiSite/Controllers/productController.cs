using AutoMapper;
using DTO;
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
        private readonly IMapper _mapper;

        public productController(IproductService productService , IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        // GET: api/<productController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> getProductAsync(int? position, int? skip, string? name, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable<Product> products= await _productService.getProductAsync(position, skip, name, minPrice, maxPrice,  categoryIds);
            IEnumerable<ProductDTO> productDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return products != null ? Ok(productDTO): BadRequest();
        }

       
    }
}
