namespace CoupleSchedule.Application.Presence.UseCases.Queries.GetMyStatus;

public interface IGetMyStatusHandler
{
    Task<MyStatusDto> ExecuteAsync(GetMyStatusQuery query, CancellationToken ct);
}