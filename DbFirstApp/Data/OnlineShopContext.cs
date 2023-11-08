using System;
using System.Collections.Generic;
using DbFirstApp.Models;
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

        modelBuilder.Entity<Address>(entity =>
        {
            entity
                .HasOne(a => a.User)
                .WithOne(u => u.Address)
                .HasForeignKey<Address>(a => a.UserId);
        });
        
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasIndex(e => e.Name, "Brands_b_name_key").IsUnique();
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(ci => new { ci.UserId, ci.ProductVersionId });
        });
        
        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasIndex(e => e.Name, "Colors_c_name_key").IsUnique();
        });
        
        modelBuilder.Entity<Media>(entity =>
        {
            entity.HasIndex(e => new { e.FileType, e.FileName }, "Medias_file_type_file_name_key").IsUnique();
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(oi => new { oi.OrderId, oi.ProductVersionId });
        });
        
        modelBuilder.Entity<OrderTransaction>(entity =>
        {
            entity.HasKey(e => new {e.Id, e.OrderTransactionStatus});
            
            entity
                .HasOne(ot => ot.Order)
                .WithOne(o => o.OrderTransaction)
                .HasForeignKey<OrderTransaction>(ot => ot.Id);
        });
        
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.Name, "Products_p_name_key").IsUnique();
        });
        
        modelBuilder.Entity<ProductVersion>(entity =>
        {
            entity.HasIndex(e => e.Sku, "ProductVersions_sku_key").IsUnique();
        });
        
        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasIndex(e => e.Name, "Sections_name_key").IsUnique();
        });
        
        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasIndex(e => e.Name, "Sizes_name_key").IsUnique();
        });
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => new { e.Email, e.Phone }, "Users_email_phone_key").IsUnique();
        });
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
