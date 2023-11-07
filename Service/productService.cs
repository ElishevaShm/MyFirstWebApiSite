using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class productService : IproductService
    {
        private readonly IproductRepository _productRepository;

        public productService(IproductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> getProductAsync()
        {
            return await _productRepository.getProductAsync();
        }
    }
}
