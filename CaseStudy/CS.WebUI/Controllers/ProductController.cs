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
}
