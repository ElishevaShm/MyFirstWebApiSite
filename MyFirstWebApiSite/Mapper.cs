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
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
        }

        
    }
}
