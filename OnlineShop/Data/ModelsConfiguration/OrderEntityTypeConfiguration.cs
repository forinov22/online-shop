using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace DbFirstApp.Data.ModelsConfiguration;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("Orders_pkey");

        builder
            .Property(e => e.AddressId)
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.CreatedAt)
            .HasColumnType("timestamp without time zone");

        builder
            .Property(e => e.Price)
            .HasColumnType("money");

        builder
            .Property(e => e.UserId)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(d => d.Address)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.AddressId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(d => d.User)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
