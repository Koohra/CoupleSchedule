using CoupleSchedule.Domain.Presence.Entities;

namespace CoupleSchedule.Domain.Presence.Interfaces;

public interface IPartnerRepository
{
    Task AddAsync(Partner partner);
    Task<Partner?> GetByIdAsync(Guid id);
    Task<Partner?> GetByIdNoTrackingAsync(Guid id, CancellationToken ct = default);
    void Update(Partner partner);
}