namespace CoupleSchedule.Domain.Academic.Entities;

public sealed class StudyTrack
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid PartnerId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; } = "";
    public DateTime? TargetDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private readonly List<Subject> _subjects = [];
    public IReadOnlyCollection<Subject> Subjects => _subjects.AsReadOnly();

    private StudyTrack()
    {
    }

    private StudyTrack(Guid partnerId, string title, string description, DateTime? targetDate = null)
    {
        PartnerId = partnerId;
        Title = title;
        Description = description;
        TargetDate = targetDate;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public static StudyTrack Create(Guid partnerId, string title, string description, DateTime? targetDate = null) =>
        new StudyTrack(partnerId, title, description, targetDate);


    public void AddSubject(string name) => _subjects.Add(new Subject(name));

    public double GetTotalProgress()
    {
        var allTopics = _subjects.SelectMany(s => s.Topics).ToList();
        if (allTopics.Count == 0)
            return 0;

        var completedCount = allTopics.Count(t => t.IsCompleted);
        return (double)completedCount / allTopics.Count * 100;
    }
}