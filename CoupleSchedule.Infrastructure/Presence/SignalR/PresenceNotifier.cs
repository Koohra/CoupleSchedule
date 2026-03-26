using CoupleSchedule.Application.Common.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace CoupleSchedule.Infrastructure.Presence.SignalR;

public sealed class PresenceNotifier(IHubContext<PresenceHub> hubContext) : IPresenceNotifier
{
    public async Task NotifyStatusUpdateAsync(Guid targetPartnerId, string name, string activity, string focusName,
        string focusDescription)
    {
        await hubContext.Clients.User(targetPartnerId.ToString()).SendAsync(
            "ReceiveStatusUpdate",
            new { Name = name, Activity = activity, FocusName = focusName, FocusDescription = focusDescription }
        );
    }
}