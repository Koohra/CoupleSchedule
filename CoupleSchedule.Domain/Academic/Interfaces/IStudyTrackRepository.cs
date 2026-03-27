using CoupleSchedule.Domain.Academic.Entities;

namespace CoupleSchedule.Domain.Academic.Interfaces;

public interface IStudyTrackRepository
{
    Task AddAsync(StudyTrack studyTrack, CancellationToken ct = default);   
    Task<StudyTrack?> GetByIdAsync(Guid id, CancellationToken ct = default);
}