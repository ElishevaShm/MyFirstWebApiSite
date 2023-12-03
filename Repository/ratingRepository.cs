using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ratingRepository: IratingRepository
    {

        private readonly WebElectricStore1Context _webElectricStore1Context;

        public ratingRepository(WebElectricStore1Context webElectricStore1Context)
        {
            _webElectricStore1Context = webElectricStore1Context;
        }

       
        public async Task<Rating> addRating(Rating rating)
        {
            await _webElectricStore1Context.Ratings.AddAsync(rating);
            await _webElectricStore1Context.SaveChangesAsync();

            return rating;
        }
    }
}
