namespace CoupleSchedule.Application.Presence.UseCases.Queries.GetPartnerStatus;

public interface IGetPartnerStatusHandler
{
    Task<PartnerStatusDTO> ExecuteAsync(GetPartnerStatusQuery query, CancellationToken ct);
}