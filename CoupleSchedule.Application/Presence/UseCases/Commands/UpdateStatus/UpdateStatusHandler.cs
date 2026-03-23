using CoupleSchedule.Domain.Common.Interfaces;
using CoupleSchedule.Domain.Presence.Interfaces;

namespace CoupleSchedule.Application.Presence.UseCases.Commands.UpdateStatus;

public sealed class UpdateStatusHandler(IPartnerRepository partnerRepo, IUnitOfWork unitOfWork) : IUpdateStatusHandler
{
    public async Task ExecuteAsync(UpdateStatusCommand command)
    {
        var partner = await partnerRepo.GetByIdAsync(command.PartnerId);
        if (partner is null)
            throw new InvalidOperationException("Partner not found");
        
        partner.UpdateStatus(command.Activity, command.Focus);
        await unitOfWork.CommitAsync();
    }
}