using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class orderService:IorderService
    
    {
        private readonly IorderRepository _orderRepository;
        public orderService(IorderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            //int[] prodId = new int[order.OrderItems.Count];
            //for(int i = 0; i < order.OrderItems.Count; i++)
            //{

            //}

            //IEnumerable<Product> listProduct = await _orderRepository.GetProductsById()
            //return //AddOrderAsync(order);

            return await _orderRepository.AddOrderAsync(order);
        }
    }
}
