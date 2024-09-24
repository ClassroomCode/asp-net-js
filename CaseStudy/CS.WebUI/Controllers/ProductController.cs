using CS.Core;
using CS.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CS.WebUI.Controllers;

public class ProductController : Controller
{
    private readonly IRepository _repository;

    public ProductController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var products = await _repository.GetAllProducts();
        var suppliers = await _repository.GetAllSuppliers();

        var vm = new HomeViewModel(products, suppliers);

        return View(vm);
    }

    [HttpGet("product/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var product = await _repository.GetProduct(id);

        if (product is null) return NotFound();

        return View(product);
    }

    [HttpGet("product/edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _repository.GetProduct(id);

        if (product is null) return NotFound();

        return View(product);
    }
}
