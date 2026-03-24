using CoupleSchedule.Domain.Identity.Entities;
using CoupleSchedule.Domain.Presence.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoupleSchedule.Infrastructure.Common.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Couple> Couples { get; set; } = null!;
    public DbSet<Partner> Partners { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}