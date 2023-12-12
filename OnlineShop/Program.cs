using System.Reflection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using OnlineShop.Data;
using OnlineShop.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var strBuilder = new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("Postgres"));
var connPass = builder.Configuration["PostgresPassword"] ?? throw new NullReferenceException("No password provided for postgres");
strBuilder.Password = connPass;

builder.Services.AddDbContext<OnlineShopContext>(opt => opt.UseNpgsql(strBuilder.ConnectionString));
builder.Services.AddMapster();

builder.Services.AddScoped<ISizeService, SizeService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductVersionService, ProductVersionService>();

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();