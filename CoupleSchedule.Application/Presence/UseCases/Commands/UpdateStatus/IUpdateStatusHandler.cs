namespace CoupleSchedule.Application.Presence.UseCases.Commands.UpdateStatus;

public interface IUpdateStatusHandler
{
    public Task ExecuteAsync(UpdateStatusCommand command);
}