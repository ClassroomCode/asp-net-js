using CS.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CS.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly IRepository _repository;
    private readonly ILogger<HomeController> _logger;

    
    public HomeController(IRepository repository, ILogger<HomeController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }
}
