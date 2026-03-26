namespace CoupleSchedule.Application.Common.Interfaces;

public interface IPresenceNotifier
{
    Task NotifyStatusUpdateAsync(
        Guid targetPartnerId,
        string name,
        string activity,
        string focusName,
        string focusDescription);
}