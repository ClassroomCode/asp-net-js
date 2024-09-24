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

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStatusCodePages();

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();

app.Run();
