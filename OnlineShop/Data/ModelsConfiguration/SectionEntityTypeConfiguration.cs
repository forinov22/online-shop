using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Models;

namespace DbFirstApp.Data.ModelsConfiguration;

public class SectionEntityTypeConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("Sections_pkey");

        builder
            .HasIndex(e => e.Name, "Sections_name_key")
            .IsUnique();

        builder
            .HasMany(d => d.Categories)
            .WithMany(p => p.Sections); 
    }
}
