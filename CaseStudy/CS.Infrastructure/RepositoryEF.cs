using CS.Core;
using Microsoft.EntityFrameworkCore;

namespace CS.Infrastructure;

public static class RepositoryFactory
{
    public static IRepository CreateRepository(string connStr) =>
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

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await Products.ToListAsync();
    }

    public async Task<IEnumerable<Supplier>> GetAllSuppliers()
    {
        return await Suppliers.ToListAsync();
    }

    public async Task<Product?> GetProduct(int id)
    {
        return await Products.SingleOrDefaultAsync(p => p.Id == id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connStr);
        optionsBuilder.LogTo(Console.WriteLine);
    }
}
