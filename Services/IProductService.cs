using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeJuniorApi.DTO;

namespace CoffeeJuniorApi.Services
{
    public interface IProductService
    {
         Task<ProductDto> GetAsync(Guid id);
         Task<IEnumerable<ProductDto>> BrowseAsync(string name = null);
         Task CreateAsync(Guid id, string name, decimal price);
         Task UpdateAsync(Guid id, string name, decimal price);
         Task DeleteAsync(Guid id);
    }
}