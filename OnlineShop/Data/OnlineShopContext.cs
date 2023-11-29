using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace DbFirstApp.Data;

public partial class OnlineShopContext : DbContext
{
    public OnlineShopContext()
    {
    }

    public OnlineShopContext(DbContextOptions<OnlineShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Media> Medias { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderTransaction> OrderTransactions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductVersion> ProductVersions { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<UserType>();
        modelBuilder.HasPostgresEnum<OrderStatus>();

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
