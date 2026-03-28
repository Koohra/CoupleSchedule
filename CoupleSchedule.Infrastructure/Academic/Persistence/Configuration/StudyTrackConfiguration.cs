using CoupleSchedule.Domain.Academic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoupleSchedule.Infrastructure.Academic.Persistence.Configuration;

public sealed class StudyTrackConfiguration : IEntityTypeConfiguration<StudyTrack>
{
    public void Configure(EntityTypeBuilder<StudyTrack> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Title).IsRequired().HasMaxLength(200);
        builder.Property(s => s.Description).HasMaxLength(200);

        builder.Metadata.FindNavigation(nameof(StudyTrack.Subjects))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        
        builder.HasMany(s => s.Subjects)
            .WithOne()
            .HasForeignKey("StudyTrackId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}