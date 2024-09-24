namespace CS.Core;

public interface IRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<IEnumerable<Supplier>> GetAllSuppliers();

    Task<Product?> GetProduct(int id);
}
