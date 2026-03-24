using CoupleSchedule.Domain.Presence.Entities;
using CoupleSchedule.Domain.Presence.Interfaces;
using CoupleSchedule.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoupleSchedule.Infrastructure.Presence.Persistence.Repositories;

public sealed class CoupleRepository(AppDbContext context) : ICoupleRepository
{
    public async Task AddAsync(Couple couple) =>
        await context.Set<Couple>().AddAsync(couple);

    public async Task<Couple?> GetByPartnerIdAsync(Guid partnerId, CancellationToken ct)
    {
        return await context.Set<Couple>()
            .FirstOrDefaultAsync(c => c.PartnerOneId == partnerId ||
                                      c.PartnerTwoId == partnerId, ct);
    }
}