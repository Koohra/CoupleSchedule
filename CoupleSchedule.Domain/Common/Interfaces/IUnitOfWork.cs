namespace CoupleSchedule.Domain.Common.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    Task<bool> CommitAsync();
}