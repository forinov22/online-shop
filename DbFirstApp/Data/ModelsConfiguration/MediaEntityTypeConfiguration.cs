using DbFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbFirstApp.Data.ModelsConfiguration;

public class MediaEntityTypeConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("Medias_pkey");

        builder
            .HasIndex(e => new { e.FileType, e.FileName }, "Medias_file_type_file_name_key")
            .IsUnique();

        builder
            .Property(e => e.ProductId)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(d => d.Product)
            .WithMany(p => p.Media)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("Medias_m_product_id_fkey");
    }
}
