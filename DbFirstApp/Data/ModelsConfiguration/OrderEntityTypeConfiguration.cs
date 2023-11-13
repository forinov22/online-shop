using DbFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbFirstApp.Data.ModelsConfiguration;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("Orders_pkey");

        builder
            .Property(e => e.AdressId)
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
            .HasOne(d => d.Adress)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.AdressId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Orders_adress_id_fkey");

        builder
            .HasOne(d => d.User)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Orders_o_user_id_fkey");
    }
}
