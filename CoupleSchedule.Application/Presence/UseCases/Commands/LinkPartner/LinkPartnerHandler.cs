using CoupleSchedule.Domain.Common.Interfaces;
using CoupleSchedule.Domain.Identity.Interfaces;
using CoupleSchedule.Domain.Presence.Entities;
using CoupleSchedule.Domain.Presence.Interfaces;

namespace CoupleSchedule.Application.Presence.UseCases.Commands.LinkPartner;

public sealed class LinkPartnerHandler(
    IUserRepository userRepo,
    ICoupleRepository coupleRepo,
    IUnitOfWork unitOfWork) : ILinkPartnerHandler
{
    public async Task ExecuteAsync(LinkPartnerCommand command)
    {
        var targetUser = await userRepo.GetByEmailAsync(command.PartnerEmail);
        if (targetUser is null) throw new Exception("User not found");

        var alreadyLinked = await coupleRepo.GetByPartnerIdAsync(command.MyId, default);
        if (alreadyLinked is not null) 
            throw new Exception("You already have a partner");

        var alreadyLinkedToPartner = await coupleRepo.GetByPartnerIdAsync(targetUser.Id, default);
        if (alreadyLinkedToPartner is not null) 
            throw new Exception("This user already has a partner");

        var newCouple = new Couple(command.MyId, targetUser.Id);
        await coupleRepo.AddAsync(newCouple);
        await unitOfWork.CommitAsync();
    }
}