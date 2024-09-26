using CS.Core;
using CS.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CS.Tests;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        var stub = new StubRepository();
        var pc = new ProductController(stub, null);

        var r = await pc.Details(1);

        Assert.IsAssignableFrom<ViewResult>(r);
        var vr = r as ViewResult;

        Assert.IsAssignableFrom<Product>(vr!.Model);

        var model = vr.Model as Product;
        Assert.Equal("Brea", model!.ProductName);
    }
}