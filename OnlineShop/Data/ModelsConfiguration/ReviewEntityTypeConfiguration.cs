using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace DbFirstApp.Data.ModelsConfiguration;

public class ReviewEntityTypeConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {

        builder
            .HasKey(e => e.Id)
            .HasName("Reviews_pkey");

        builder
            .Property(e => e.CreatedAt)
            .HasColumnType("timestamp without time zone");

        builder
            .Property(e => e.ProductId)
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.UserId)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(d => d.Product).WithMany(p => p.Reviews)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(d => d.User).WithMany(p => p.Reviews)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
