using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace DbFirstApp.Data.ModelsConfiguration;

public class ProductVersionEntityTypeConfiguration : IEntityTypeConfiguration<ProductVersion>
{
    public void Configure(EntityTypeBuilder<ProductVersion> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("ProductVersions_pkey");

        builder
            .HasIndex(e => e.Sku, "ProductVersions_sku_key")
            .IsUnique();

        builder
            .Property(e => e.ColorId)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.ProductId)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.SizeId)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(d => d.Color)
            .WithMany(p => p.ProductVersions)
            .HasForeignKey(d => d.ColorId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(d => d.Product)
            .WithMany(p => p.ProductVersions)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(d => d.Size)
            .WithMany(p => p.ProductVersions)
            .HasForeignKey(d => d.SizeId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
