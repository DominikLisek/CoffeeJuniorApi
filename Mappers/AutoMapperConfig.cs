using AutoMapper;
using CoffeeJuniorApi.DTO;
using CoffeeJuniorApi.Models;

namespace CoffeeJuniorApi.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>();
            })
            .CreateMapper();
    }
}