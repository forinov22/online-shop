using System.Reflection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using OnlineShop.Data;
using OnlineShop.Exceptions;
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
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

var app = builder.Build();

//app.MigrateDb();

app.UseExceptionHandling();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();