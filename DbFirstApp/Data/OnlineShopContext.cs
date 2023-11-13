using System;
using System.Collections.Generic;
using DbFirstApp.Models;
using DbFirstApp.Data.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("User ID=postgres;Password=2209;Host=localhost;Port=5432;Database=online-shop;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<UserType>();
        modelBuilder.HasPostgresEnum<OrderStatus>();

        new AddressEntityTypeConfiguration().Configure(modelBuilder.Entity<Address>());
        new BrandEntityTypeConfiguration().Configure(modelBuilder.Entity<Brand>());
        new CartItemEntityTypeConfiguration().Configure(modelBuilder.Entity<CartItem>());
        new CategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Category>());
        new ColorEntityTypeConfiguration().Configure(modelBuilder.Entity<Color>());
        new MediaEntityTypeConfiguration().Configure(modelBuilder.Entity<Media>());
        new OrderEntityTypeConfiguration().Configure(modelBuilder.Entity<Order>());
        new OrderItemEntityTypeConfiguration().Configure(modelBuilder.Entity<OrderItem>());
        new OrderTransactionEntityTypeConfiguration().Configure(modelBuilder.Entity<OrderTransaction>());
        new ProductEntityTypeConfiguration().Configure(modelBuilder.Entity<Product>());
        new ProductVersionEntityTypeConfiguration().Configure(modelBuilder.Entity<ProductVersion>());
        new ReviewEntityTypeConfiguration().Configure(modelBuilder.Entity<Review>());
        new SectionEntityTypeConfiguration().Configure(modelBuilder.Entity<Section>());
        new SizeEntityTypeConfiguration().Configure(modelBuilder.Entity<Size>());
        new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
    }
}
