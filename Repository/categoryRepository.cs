using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class categoryRepository:IcategoryRepository
    {
        private readonly WebElectricStore1Context _webElectricStore1Context;


        public categoryRepository(WebElectricStore1Context webElectricStore1Context)
        {
            _webElectricStore1Context = webElectricStore1Context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _webElectricStore1Context.Categories.ToListAsync();
        }
    }
}
