using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace DbFirstApp.Data.ModelsConfiguration;

public class ColorEntityTypeConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("Colors_pkey");

        builder
            .HasIndex(e => e.Name, "Colors_name_key")
            .IsUnique();
    }
}
