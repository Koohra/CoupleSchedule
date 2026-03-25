using CoupleSchedule.Application.Common.Interfaces;
using CoupleSchedule.Domain.Common.Interfaces;
using CoupleSchedule.Domain.Identity.Entities;
using CoupleSchedule.Domain.Identity.Interfaces;
using CoupleSchedule.Domain.Presence.Entities;
using CoupleSchedule.Domain.Presence.Interfaces;

namespace CoupleSchedule.Application.Identity.UseCases.Commands.RegisterPartner;

public sealed class RegisterPartnerHandler(
    IUserRepository userRepo, 
    IPartnerRepository partnerRepo, 
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher) : IRegisterPartnerHandler
{
    public async Task ExecuteAsync(RegisterPartnerCommand command)
    {
        if (await userRepo.EmailExistsAsync(command.Email))
            throw new InvalidOperationException("Email already exists");
        
        var passwordHash = passwordHasher.Hash(command.Password);
        
        var newUser = new User(command.Email,passwordHash);
        var newPartner = new Partner(newUser.Id, command.Name);
        
        await userRepo.AddAsync(newUser);
        await partnerRepo.AddAsync(newPartner);
        await unitOfWork.CommitAsync();
    }
}