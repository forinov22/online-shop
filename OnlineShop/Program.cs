using DbFirstApp.Data;
using OnlineShop.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<OnlineShopContext>();

builder.Services.AddScoped<IBrandService, BrandService>();

var app = builder.Build();

app.MapControllers();

app.Run();