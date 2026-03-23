using CoupleSchedule.Domain.Identity.Entities;
using CoupleSchedule.Domain.Presence.Entities;
using CoupleSchedule.Domain.Presence.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoupleSchedule.Infrastructure.Presence.Persistence.Configuration;

public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne<User>()
            .WithOne()
            .HasForeignKey<Partner>(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.CurrentFocus)
            .HasConversion(
                focus => focus.Id,
                id => FocusLevel.FromId(id)
            )
            .HasColumnName("focus_level_id");
            
        builder.Property(p => p.CurrentActivity).HasMaxLength(200);
        builder.ToTable("partners");
    }
}