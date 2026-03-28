using CoupleSchedule.Domain.Academic.Entities;
using CoupleSchedule.Domain.Academic.Interfaces;
using CoupleSchedule.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoupleSchedule.Infrastructure.Academic.Persistence.Repositories;

public sealed class StudyTrackRepository(AppDbContext context) : IStudyTrackRepository
{
    public async Task AddAsync(StudyTrack studyTrack, CancellationToken ct = default) =>
        await context.StudyTracks.AddAsync(studyTrack, ct);

    public async Task<StudyTrack?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        await context.StudyTracks
            .Include(s => s.Subjects)
            .ThenInclude(t => t.Topics)
            .FirstOrDefaultAsync(c => c.Id == id, ct);
}