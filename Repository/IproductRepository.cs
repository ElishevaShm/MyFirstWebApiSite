using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IproductRepository
    {
        Task<IEnumerable<Product>> getProductAsync(int? position, int? skip, string? name, int? minPrice, int? maxPrice, int?[] categoryIds); 
    }
}
