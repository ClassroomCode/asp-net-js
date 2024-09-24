using CS.Core;

namespace CS.WebUI.ViewModels;

public record HomeViewModel(
    IEnumerable<Product> Products, 
    IEnumerable<Supplier> Suppliers
);

