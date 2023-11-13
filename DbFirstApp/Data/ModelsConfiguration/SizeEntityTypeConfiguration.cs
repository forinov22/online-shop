using DbFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbFirstApp.Data.ModelsConfiguration;

public class SizeEntityTypeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {    
        builder
            .HasKey(e => e.Id)
            .HasName("Sizes_pkey");

        builder
            .HasIndex(e => e.Name, "Sizes_s_name_key")
            .IsUnique();
    }
}
