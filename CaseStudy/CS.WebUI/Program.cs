using CS.Core;
using CS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("ConnStr");
if (connStr is null) {
    // TODO: something
}
else {
    builder.Services.AddScoped<IRepository>(_ =>
        RepositoryFactory.Create(connStr));
}

builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStatusCodePages();

app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();

app.Run();
