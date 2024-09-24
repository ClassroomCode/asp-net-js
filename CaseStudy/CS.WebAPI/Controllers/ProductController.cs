using CS.Core;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebAPI.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProductController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("products")]
        public async Task<IActionResult> AllProducts() 
        {
            var products = await _repository.GetAllProducts();

            var r = products.Select(p => new {
                name = p.ProductName,
                price = p.UnitPrice
            });

            return Ok(r);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> Product(int id)
        {
            var product = await _repository.GetProduct(id);

            if (product is null) return NotFound();

            return Ok(product);
        }
    }
}
