using CoupleSchedule.Domain.Presence.Interfaces;

namespace CoupleSchedule.Application.Presence.UseCases.Queries.GetMyStatus;

public sealed class GetMyStatusHandler(IPartnerRepository partnerRepo) : IGetMyStatusHandler
{
    public async Task<MyStatusDto> ExecuteAsync(GetMyStatusQuery query, CancellationToken ct)
    {
        var partner = await partnerRepo.GetByIdNoTrackingAsync(query.MyId, ct);
        
        if (partner is null) 
            throw new InvalidOperationException("Partner not found");

        return new MyStatusDto(
            Name: partner.Name,
            Activity: partner.CurrentActivity,
            FocusDescription: partner.CurrentFocus.Description,
            FocusName: partner.CurrentFocus.Name,
            LastSeen: partner.LastSeen
        );
    }
}