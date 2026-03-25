using System.Security.Claims;
using CoupleSchedule.Application.Presence.UseCases.Commands.LinkPartner;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Presence.LinkPartner;

public sealed class LinkPartnerEndpoint(ILinkPartnerHandler handler) 
    : Endpoint<LinkPartnerRequest>
{
    public override void Configure()
    {
        Post("/partners/link");
    }

    public override async Task HandleAsync(LinkPartnerRequest req, CancellationToken ct)
    {
        var myId = User.FindFirstValue("id");
        var command = new LinkPartnerCommand(Guid.Parse(myId!), req.PartnerEmail);
        
        await handler.ExecuteAsync(command);
        await Send.NoContentAsync(ct);
    }
}