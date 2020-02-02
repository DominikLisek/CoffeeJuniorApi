using System.Threading.Tasks;
using CoffeeJuniorApi.Models;
using System;
using System.Collections.Generic;

namespace CoffeeJuniorApi.Repositories
{
    public interface IProductRepository
    {
         Task<Product> GetAsync(Guid id);
         Task<Product> GetAsync(string name);
         Task<IEnumerable<Product>> BrowseAsync(string name = null);
         Task AddAsync(Product product);
         Task UpdateAsync(Product product);
         Task DeleteAsync(Product product);
    }
}