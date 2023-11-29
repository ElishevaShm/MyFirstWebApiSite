using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IorderRepository
    {
        Task<Order> AddOrderAsync(Order order);
        Task<IEnumerable<Product>> GetProductsById(int[] prodsId);
    }
}
