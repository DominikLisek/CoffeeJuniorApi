using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CoffeeJuniorApi.Models
{
    public class Product
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public decimal Price {get; set;}
        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

    }
   
    
}