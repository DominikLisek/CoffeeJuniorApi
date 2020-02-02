using System;

namespace CoffeeJuniorApi.DTO
{
    public class ProductDto
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public decimal Price {get; set;}
    }
}