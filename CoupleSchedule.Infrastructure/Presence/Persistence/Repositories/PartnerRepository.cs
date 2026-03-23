using CoupleSchedule.Domain.Presence.Entities;
using CoupleSchedule.Domain.Presence.Interfaces;
using CoupleSchedule.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoupleSchedule.Infrastructure.Presence.Persistence.Repositories;

public sealed class PartnerRepository(AppDbContext context) : IPartnerRepository
{
    public async Task AddAsync(Partner partner) =>
        await context.Partners
            .AddAsync(partner);

    public async Task<Partner?> GetByIdAsync(Guid id) =>
        await context.Partners
            .FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Partner?> GetByIdNoTrackingAsync(Guid id, CancellationToken ct) => 
        await context.Partners
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken: ct);

    public void Update(Partner partner) =>
        context.Partners
            .Update(partner);
}