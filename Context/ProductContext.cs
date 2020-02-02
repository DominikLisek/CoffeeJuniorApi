using CoffeeJuniorApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeJuniorApi.Context
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            :base(options){}
        public DbSet<Product> Products {get; set;}
    }
}