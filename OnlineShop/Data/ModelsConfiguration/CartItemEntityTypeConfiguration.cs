using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domains;

namespace OnlineShop.Data.ModelsConfiguration;

public class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder
            .HasKey(e => new { e.UserId, e.ProductVersionId });

        builder
            .Property(e => e.UserId)
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.ProductVersionId)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(d => d.ProductVersion)
            .WithMany(p => p.CartItems)
            .HasForeignKey(d => d.ProductVersionId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(d => d.User)
            .WithMany(p => p.CartItems)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
