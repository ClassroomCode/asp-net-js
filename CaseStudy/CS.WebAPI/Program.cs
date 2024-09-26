using CS.Core;
using CS.Infrastructure;
using CS.WebAPI.Auth;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("MyCustomAuth")
    .AddScheme<AuthenticationSchemeOptions, MyCustomAuthHandler>
        ("MyCustomAuth", options => { });

builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminsOnly", policy =>
    policy.RequireClaim(ClaimTypes.Role, "Admin"));
});

var connStr = builder.Configuration.GetConnectionString("ConnStr");
if (connStr is null) {
    // TODO: something
}
else {
    builder.Services.AddScoped<IRepository>(_ =>
        RepositoryFactory.Create(connStr));
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy(name: "AllowedOrigins",
        builder => {
            builder.AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowedOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
