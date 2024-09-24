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
        public async Task<IEnumerable<Product>> AllProducts() 
        {
            var products = await _repository.GetAllProducts();

            return products;
        }
    }
}
