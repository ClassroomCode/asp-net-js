using CS.Core;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebUI.Controllers;

public class ProductController : Controller
{
    private readonly IRepository _repository;

    public ProductController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("productsmvc")]
    public async Task<IActionResult> Index()
    {
        var products = await _repository.GetAllProducts();

        return View(products);
    }
}
