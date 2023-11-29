using Entity;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<orderService> _logger;

        public orderService(IorderRepository orderRepository,ILogger<orderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            int[] prodId = new int[order.OrderItems.Count];
            int totalSumClient = (int)order.OrderSum;
            double totalSumDb = 0;

            for (int i = 0; i < order.OrderItems.Count; i++)
            {
                prodId[i] = (int)order.OrderItems.ElementAt(i).ProductId;
            }

            IEnumerable<Product> listProduct = await _orderRepository.GetProductsById(prodId);
            foreach (Product product in listProduct)
            {
                totalSumDb += product.Price;
            }
            if(totalSumClient!=totalSumDb)
                _logger.LogError("the totalSum != orderSum");
            order.OrderSum = (int)totalSumDb;
            return await _orderRepository.AddOrderAsync(order);
            
        }
    }
}
