using CoupleSchedule.Domain.Common.Interfaces;

namespace CoupleSchedule.Infrastructure.Common.Persistence;

public sealed class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync() =>
        await context.SaveChangesAsync();

    public async Task<bool> CommitAsync() =>
        await SaveChangesAsync() > 0;
    
    public void Dispose() => context.Dispose();
}