using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domains;

namespace OnlineShop.Data.ModelsConfiguration;

public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .HasKey(e => new { e.OrderId, e.ProductVersionId });

        builder
            .Property(e => e.OrderId)
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.ProductVersionId)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(d => d.Order)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(d => d.ProductVersion)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.ProductVersionId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
