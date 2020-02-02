using System;
using System.Linq;
using CoffeeJuniorApi.Context;
using CoffeeJuniorApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeJuniorApi
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new ProductContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProductContext>>()))
            {
                if(context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(
                    new Product(Guid.NewGuid(),"Water",12),
                    new Product(Guid.NewGuid(),"Coca-cola",33)
                );
                context.SaveChanges();
            }
        }
    }
}