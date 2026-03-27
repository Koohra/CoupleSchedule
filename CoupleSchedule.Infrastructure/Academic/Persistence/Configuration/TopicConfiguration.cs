using CoupleSchedule.Domain.Academic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoupleSchedule.Infrastructure.Academic.Persistence.Configuration;

public sealed class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(200);

        builder.OwnsOne(t => t.Load, load =>
        {
            load.Property(l => l.Value).HasColumnName("CognitiveLoadValue");
            load.Property(l => l.Description)
                .HasColumnName("CognitiveLoadDescription")
                .HasMaxLength(500);
        });
    }
}