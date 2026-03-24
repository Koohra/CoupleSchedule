using CoupleSchedule.Domain.Presence.Entities;

namespace CoupleSchedule.Domain.Presence.Interfaces;

public interface ICoupleRepository
{
    Task AddAsync(Couple couple);                                                                                  
    Task<Couple?> GetByPartnerIdAsync(Guid partnerId, CancellationToken ct);                                          
}