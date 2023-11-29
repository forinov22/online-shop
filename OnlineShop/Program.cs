using DbFirstApp.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using OnlineShop;
using OnlineShop.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var strBuilder = new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("Postgres"));
var connPass = builder.Configuration["PostgresPassword"] ?? throw new NullReferenceException("No password provided for postgres");
strBuilder.Password = connPass;

builder.Services.AddDbContext<OnlineShopContext>(opt => opt.UseNpgsql(strBuilder.ConnectionString));

builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IProductVersionService, ProductVersionService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();