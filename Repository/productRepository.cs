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
        public async Task<IEnumerable<Product>> getProductAsync(int? position, int? skip,string? name,int? minPrice, int? maxPrice, int?[]categoryIds )
        {
            var query = _webElectricStore1Context.Products.Where(product =>
            (name == null ? (true) : (product.Name.Contains(name)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price >= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId)))
            ).OrderBy(product => product.Price);
            

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsById(int[] prodsId)
        {
            var query = _webElectricStore1Context.Products.Where(p => prodsId.Contains(p.ProductId));
            return await query.ToListAsync();

        }
    }
}
