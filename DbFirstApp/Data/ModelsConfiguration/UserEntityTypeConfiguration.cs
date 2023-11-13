using DbFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbFirstApp.Data.ModelsConfiguration;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("Users_pkey");

        builder
            .HasIndex(e => new { e.Email, e.Phone }, "Users_u_email_u_phone_key")
            .IsUnique();
    }
}
