using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeJuniorApi.DTO;
using CoffeeJuniorApi.Models;
using CoffeeJuniorApi.Repositories;

namespace CoffeeJuniorApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            return _mapper.Map<ProductDto>(product);
        }
        public async Task<IEnumerable<ProductDto>> BrowseAsync(string name = null)
        {
            var products = await _productRepository.BrowseAsync(name);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        public async Task CreateAsync(Guid id, string name, decimal price)
        {
            var product = await _productRepository.GetAsync(name);
            if(product != null)
            {
                throw new Exception($"Product named: '{name}' already exists.");
            }
            product = new Product(id, name, price);
            await _productRepository.AddAsync(product);
        }
        public async Task UpdateAsync(Guid id, string name, decimal price)
        {
            var product = await _productRepository.GetAsync(name);
            if(product != null && product.Id != id)
            {
                throw new Exception($"Product named: '{name}' already exists.");
            }
            product = await _productRepository.GetAsync(id);
            if(product == null)
            {
                throw new Exception($"Product with id: {id} - doesn't exists.");
            }
            product.Name = name;
            product.Price = price;
            await _productRepository.UpdateAsync(product);
        }
        public async Task DeleteAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            if(product == null)
            {
                throw new Exception($"Product with id: {id} - doesn't exists.");
            }
            await _productRepository.DeleteAsync(product);
        }
    }
}