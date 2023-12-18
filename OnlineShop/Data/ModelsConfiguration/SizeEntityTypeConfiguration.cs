using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domains;

namespace OnlineShop.Data.ModelsConfiguration;

public class SizeEntityTypeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {    
        builder
            .HasKey(e => e.Id);

        builder
            .HasIndex(e => e.Name, "Sizes_s_name_key")
            .IsUnique();
    }
}
