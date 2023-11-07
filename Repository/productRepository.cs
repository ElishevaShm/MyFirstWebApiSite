using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class productRepository : IproductRepository
    {
        private readonly WebElectricStore1Context _webElectricStore1Context;

        public productRepository(WebElectricStore1Context webElectricStore1Context)
        {
            _webElectricStore1Context = webElectricStore1Context;
        }
        public async Task<IEnumerable<Product>> getProductAsync()
        {
            return await _webElectricStore1Context.Products.ToListAsync();
        }
    }
}
