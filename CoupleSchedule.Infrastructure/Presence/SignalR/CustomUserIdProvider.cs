using Microsoft.AspNetCore.SignalR;

namespace CoupleSchedule.Infrastructure.Presence.SignalR;

public sealed class CustomUserIdProvider : IUserIdProvider
{
    public string? GetUserId(HubConnectionContext connection)
    {
        return connection.User.FindFirst("id")?.Value;
    }
}