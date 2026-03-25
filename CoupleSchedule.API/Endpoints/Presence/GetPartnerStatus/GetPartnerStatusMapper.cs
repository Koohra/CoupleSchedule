using CoupleSchedule.Application.Presence.UseCases.Queries.GetPartnerStatus;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Presence.GetPartnerStatus;

public sealed class GetPartnerStatusMapper : ResponseMapper<GetPartnerStatusResponse, PartnerStatusDto>
{
    public override GetPartnerStatusResponse FromEntity(PartnerStatusDto d) => new(
        Name: d.Name,
        Activity: d.Activity,
        FocusName: d.FocusName,
        FocusDescription: d.FocusDescription,
        LastSeen: d.LastSeen
    );
}