using CS.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS.WebUI.Pages
{
    [Authorize(Policy = "AdminsOnly")]
    public class ProductsRazorModel : PageModel
    {
        private readonly IRepository _repository;

        public ProductsRazorModel(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> Products { get; set; } = Array.Empty<Product>();
        public IEnumerable<Supplier> Suppliers { get; set; } = Array.Empty<Supplier>();


        public async Task OnGet()
        {
            Products = await _repository.GetAllProducts();
            Suppliers = await _repository.GetAllSuppliers();
        }
    }
}
