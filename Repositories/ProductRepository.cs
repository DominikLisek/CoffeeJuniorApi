using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeJuniorApi.Context;
using CoffeeJuniorApi.Models;

namespace CoffeeJuniorApi.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private static readonly ISet<Product> _products = new HashSet<Product>()
        {
            new Product(Guid.NewGuid(),"Name",22)
        };
        private ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public async Task<Product> GetAsync(Guid id)
            => await Task.FromResult(_context.Products.SingleOrDefault(x => x.Id == id));
        public async Task<Product> GetAsync(string name)
            => await Task.FromResult(_context.Products.SingleOrDefault(x => 
                x.Name.ToLowerInvariant() == name.ToLowerInvariant()));
        public async Task<IEnumerable<Product>> BrowseAsync(string name = null)
        {
            var products = _context.Products.Where(x => x.Name != "");
            if(!string.IsNullOrWhiteSpace(name))
            {
                products = products.Where(x => x.Name.ToLowerInvariant()
                    .Contains(name.ToLowerInvariant()));
            }
            return await Task.FromResult(products.ToList());
        }
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            await Task.CompletedTask;
        } 

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            await Task.CompletedTask;
        }
    }
}