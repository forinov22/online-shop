using DbFirstApp.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using OnlineShop;
using OnlineShop.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


var strBuilder = new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("Postgres"));
var connPass = builder.Configuration["PostgresPassword"] ?? throw new NullReferenceException("No password provided for postgres");
strBuilder.Password = connPass;

builder.Services.AddDbContext<OnlineShopContext>(opt => opt.UseNpgsql(strBuilder.ConnectionString));

builder.Services.AddScoped<IBrandService, BrandService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

app.MapControllers();

app.Run();