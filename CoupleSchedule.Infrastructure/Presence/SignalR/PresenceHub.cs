using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace CoupleSchedule.Infrastructure.Presence.SignalR;

[Authorize]
public sealed class PresenceHub : Hub
{
    
}