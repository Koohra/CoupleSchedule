namespace CoupleSchedule.Application.Presence.UseCases.Queries.GetPartnerStatus;

public interface IGetPartnerStatusHandler
{
    Task<PartnerStatusDto> ExecuteAsync(GetPartnerStatusQuery query, CancellationToken ct);
}