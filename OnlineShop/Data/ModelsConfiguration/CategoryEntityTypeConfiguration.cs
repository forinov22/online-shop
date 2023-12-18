using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domains;

namespace OnlineShop.Data.ModelsConfiguration;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .HasIndex(e => e.Name, "Categories_name_key")
            .IsUnique();

        builder
            .Property(e => e.ParentCategoryId)
            .ValueGeneratedOnAdd();
    }
}
