using DbFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbFirstApp.Data.ModelsConfiguration;

public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("Adresses_pkey");

        builder
            .Property(e => e.UserId)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(d => d.User)
            .WithOne(p => p.Address)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
