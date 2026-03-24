using CoupleSchedule.Domain.Presence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoupleSchedule.Infrastructure.Presence.Persistence.Configuration;

public sealed class CoupleConfiguration : IEntityTypeConfiguration<Couple>
{
    public void Configure(EntityTypeBuilder<Couple> builder)
    {
        builder.ToTable("couples");
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.PartnerOneId).IsRequired();
        builder.Property(c => c.PartnerTwoId).IsRequired();
        
        builder.HasIndex(c => new { c.PartnerOneId, c.PartnerTwoId }).IsUnique();
        
        builder.Property(c => c.CreatedAt).IsRequired();
    }
}