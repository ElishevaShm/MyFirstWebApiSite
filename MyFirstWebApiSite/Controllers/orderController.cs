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
    public class orderController : ControllerBase
    {

        private readonly IorderService _orderService;
        private readonly IMapper _mapper;

        public orderController(IorderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;

        }

        // POST api/<orderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder(OrderDTO orders)
        {
            
                Order order = _mapper.Map<OrderDTO, Order>(orders);
                Order orderCreate = await _orderService.AddOrderAsync(order);
                OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(orderCreate);
                return orderCreate !=null ? CreatedAtAction(nameof(AddOrder), new {id = orderDTO.UserId }, orderDTO):NoContent();
        

}
    }
}
