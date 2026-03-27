using CoupleSchedule.Domain.Academic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoupleSchedule.Infrastructure.Academic.Persistence.Configuration;

public sealed class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(200);
        
        builder.Metadata.FindNavigation(nameof(Subject.Topics))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.HasMany(s => s.Topics)
            .WithOne()
            .HasForeignKey("SubjectId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}