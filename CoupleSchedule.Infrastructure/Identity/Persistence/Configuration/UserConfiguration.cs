using CoupleSchedule.Domain.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoupleSchedule.Infrastructure.Identity.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.ToTable("users");
    }
}