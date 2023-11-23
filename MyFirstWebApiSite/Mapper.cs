using AutoMapper;
using DTO;
using Entity;

namespace MyFirstWebApiSite
{
    public class Mapper: Profile
    {
        public Mapper()
        { 
           CreateMap<Product, ProductDTO>().ReverseMap();
        }

        
    }
}
