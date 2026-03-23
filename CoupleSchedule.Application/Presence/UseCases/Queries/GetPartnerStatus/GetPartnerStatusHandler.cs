using CoupleSchedule.Domain.Presence.Interfaces;

namespace CoupleSchedule.Application.Presence.UseCases.Queries.GetPartnerStatus;

public sealed class GetPartnerStatusHandler(IPartnerRepository partnerRepo) : IGetPartnerStatusHandler
{
    public async Task<PartnerStatusDTO> ExecuteAsync(GetPartnerStatusQuery query, CancellationToken ct)
    {
        var partner = await partnerRepo.GetByIdNoTrackingAsync(query.PartnerId, ct);
        
        if (partner is null)
            throw new InvalidOperationException("Partner not found");

        return new PartnerStatusDTO(
            Name: partner.Name,
            Activity: partner.CurrentActivity,
            FocusDescription: partner.CurrentFocus.Description,
            FocusName: partner.CurrentFocus.Name,
            LastSeen: partner.LastSeen
        );
    }
}