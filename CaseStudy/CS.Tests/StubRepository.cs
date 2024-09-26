using CS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Tests;

internal class StubRepository : IRepository
{
    public Task AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllProducts(bool includeSuppliers = false)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Supplier>> GetAllSuppliers()
    {
        throw new NotImplementedException();
    }

    public async Task<Product?> GetProduct(int id, bool includeSupplier = false)
    {
        var product = new Product {
            Id = 1,
            ProductName = "Bread",
            UnitPrice = 15.00M,
            Package = "Bag",
            IsDiscontinued = false,
            SupplierId = 1
        };
        if (includeSupplier) {
            product.Supplier = new Supplier {
                Id = 1,
                CompanyName = "Acme, Inc."
            };
        }
        return await Task.Run(() => product);
    }

    public Task<bool> SaveProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
