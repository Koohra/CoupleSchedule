using CoupleSchedule.Application.Presence.UseCases.Queries.GetPartnerStatus;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Presence.GetPartnerStatus;

public sealed class GetPartnerStatusMapper : Mapper<GetPartnerStatusRequest, GetPartnerStatusResponse, GetPartnerStatusQuery>
{
    public override GetPartnerStatusQuery ToEntity(GetPartnerStatusRequest r) 
        => new(PartnerId: Guid.Empty);

    public GetPartnerStatusResponse FromDto(PartnerStatusDTO d) => new(
        Name: d.Name,
        Activity: d.Activity,
        FocusName: d.FocusName,
        FocusDescription: d.FocusDescription,
        LastSeen: d.LastSeen
    );

}