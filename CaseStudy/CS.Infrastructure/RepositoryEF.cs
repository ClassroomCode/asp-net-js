using CS.Core;
using Microsoft.EntityFrameworkCore;

namespace CS.Infrastructure;

public static class RepositoryFactory
{
    public static IRepository Create(string connStr) =>
        new RepositoryEF(connStr);
}

internal class RepositoryEF : DbContext, IRepository
{
    private readonly string _connStr;

    public RepositoryEF(string connStr)
    {
        _connStr = connStr;
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();

    public async Task AddProduct(Product product)
    {
        Products.Add(product);
        await SaveChangesAsync();
    }

    public async Task<bool> DeleteProduct(Product product)
    {
        Products.Remove(product);
        int rowsAffected = await SaveChangesAsync();
        return (rowsAffected > 0);
    }

    public async Task<IEnumerable<Product>> GetAllProducts(bool includeSuppliers = false)
    {
        return includeSuppliers switch {
            true => await Products.AsNoTracking().Include(p => p.Supplier).ToListAsync(),
            false => await Products.AsNoTracking().ToListAsync()
        };
    }

    public async Task<IEnumerable<Supplier>> GetAllSuppliers()
    {
        return await Suppliers.OrderBy(s => s.CompanyName).ToListAsync();
    }

    public async Task<Product?> GetProduct(int id, bool includeSupplier = false)
    {
        return includeSupplier switch {
            true => await Products.Include(p => p.Supplier)
                    .SingleOrDefaultAsync(p => p.Id == id),
            false => await Products.SingleOrDefaultAsync(p => p.Id == id)
        };
    }

    public async Task<bool> SaveProduct(Product product)
    {
        var existingProduct = await Products.SingleOrDefaultAsync(p => p.Id == product.Id);
        if (existingProduct is null) return false;

        existingProduct.ProductName = product.ProductName;
        existingProduct.UnitPrice = product.UnitPrice;
        existingProduct.Package = product.Package;
        existingProduct.IsDiscontinued = product.IsDiscontinued;
        existingProduct.SupplierId = product.SupplierId;

        int rowsAffected = await SaveChangesAsync();
        return (rowsAffected > 0);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connStr);
        optionsBuilder.LogTo(Console.WriteLine);
    }
}
