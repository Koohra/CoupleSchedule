using CoupleSchedule.Domain.Presence.Interfaces;

namespace CoupleSchedule.Application.Presence.UseCases.Queries.GetPartnerStatus;

public sealed class GetPartnerStatusHandler(IPartnerRepository partnerRepo, ICoupleRepository coupleRepo)
    : IGetPartnerStatusHandler
{
    public async Task<PartnerStatusDTO> ExecuteAsync(GetPartnerStatusQuery query, CancellationToken ct)
    {
        var couple = await coupleRepo.GetByPartnerIdAsync(query.PartnerId, ct);

        if (couple is null)
            throw new InvalidOperationException("You don't have a partner yet");

        var targetPartnerId = couple.GetOtherPartnerId(query.PartnerId);

        var partner = await partnerRepo.GetByIdNoTrackingAsync(targetPartnerId, ct);

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