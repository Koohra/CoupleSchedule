using CoupleSchedule.Application.Common.Interfaces;
using CoupleSchedule.Domain.Common.Interfaces;
using CoupleSchedule.Domain.Presence.Enums;
using CoupleSchedule.Domain.Presence.Interfaces;

namespace CoupleSchedule.Application.Presence.UseCases.Commands.UpdateStatus;

public sealed class UpdateStatusHandler(
    IPartnerRepository partnerRepo,
    ICoupleRepository coupleRepo,
    IPresenceNotifier notifier,
    IUnitOfWork unitOfWork) : IUpdateStatusHandler
{
    public async Task ExecuteAsync(UpdateStatusCommand command)
    {
        var partner = await partnerRepo.GetByIdAsync(command.MyId);
        if (partner is null)
            throw new InvalidOperationException("Partner not found");

        var focusLevel = FocusLevel.FromId(command.Focus);

        partner.UpdateStatus(command.Activity, focusLevel);
        await unitOfWork.CommitAsync();

        var couple = await coupleRepo.GetByPartnerIdAsync(command.MyId, default);
        if (couple is not null)
        {
            var targetPartnerId = couple.GetOtherPartnerId(command.MyId);
            await notifier.NotifyStatusUpdateAsync(
                targetPartnerId,
                partner.Name,
                partner.CurrentActivity,
                partner.CurrentFocus.Name,
                partner.CurrentFocus.Description);
        }
    }
}