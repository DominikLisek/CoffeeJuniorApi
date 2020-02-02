using System;
using System.Linq;
using System.Threading.Tasks;
using CoffeeJuniorApi.DTO;
using CoffeeJuniorApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeJuniorApi.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }   

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var products = await _productService.BrowseAsync(null);
            return Json(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productService.GetAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return Json(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductCreateRequestDto productDto)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(string.Join("\n", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)));
            }
            
            productDto.Id = Guid.NewGuid();
            await _productService.CreateAsync(productDto.Id,productDto.Name,productDto.Price);
            return StatusCode(201, productDto.Id.ToString());

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]ProductUpdateRequestDto productDto)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(string.Join("\n", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)));
            }

            await _productService.UpdateAsync(id, productDto.Name, productDto.Price);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            await _productService.DeleteAsync(id);
            return NoContent();
        }

    }
}