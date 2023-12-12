using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domains;

namespace OnlineShop.Data.ModelsConfiguration;

public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.UserId)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(d => d.User)
            .WithOne(p => p.Address)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
