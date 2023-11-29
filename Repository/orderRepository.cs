using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class orderRepository : IorderRepository

    {
        private readonly WebElectricStore1Context _webElectricStore1Context;
        public orderRepository(WebElectricStore1Context WebElectricStore1Context)
        {
            _webElectricStore1Context = WebElectricStore1Context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            await _webElectricStore1Context.Orders.AddAsync(order);
            await _webElectricStore1Context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Product>> GetProductsById(int[] prodsId)
        {
            var query = _webElectricStore1Context.Products.Where(p => prodsId.Contains(p.ProductId));
            return await query.ToListAsync();

        }
    }
}
