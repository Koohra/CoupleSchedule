using CoupleSchedule.Application.Presence.UseCases.Queries.GetMyStatus;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Presence.GetMyStatus;

public sealed class GetMyStatusMapper : ResponseMapper<GetMyStatusResponse, MyStatusDto>
{
    public override GetMyStatusResponse FromEntity(MyStatusDto d) => new(
        Name: d.Name,
        Activity: d.Activity,
        FocusName: d.FocusName,
        FocusDescription: d.FocusDescription,
        LastSeen: d.LastSeen
    );
}