using DbFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbFirstApp.Data.ModelsConfiguration;

public class OrderTransactionEntityTypeConfiguration : IEntityTypeConfiguration<OrderTransaction>
{
    public void Configure(EntityTypeBuilder<OrderTransaction> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("OrderTransactions_pkey");

        builder
            .Property(e => e.OrderId)
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.UpdatedAt)
            .HasColumnType("timestamp without time zone");

        builder
            .HasOne(d => d.Order)
            .WithMany(p => p.OrderTransactions)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("OrderTransactions_order_id_fkey");
    }
}
