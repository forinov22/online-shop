using DbFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbFirstApp.Data.ModelsConfiguration;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder
            .HasKey(e => e.Id)
            .HasName("Products_pkey");

        builder
            .HasIndex(e => e.Name, "Products_name_key")
            .IsUnique();

        builder
            .Property(e => e.BrandId)
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.CategoryId)
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.Price)
            .HasColumnType("money");

        builder
            .HasOne(d => d.Brand)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.BrandId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(d => d.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
