using CoupleSchedule.Domain.Academic.ValueObject;

namespace CoupleSchedule.Domain.Academic.Entities;

public sealed class Topic
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public bool IsCompleted { get; private set; }
    public CognitiveLoad Load { get; private set; }
    
    private Topic() { }

    public Topic(string title, CognitiveLoad load)
    {
        Title = title;
        Load = load;
        IsCompleted = false;
    }
    
    public void MarkAsCompleted() => IsCompleted = true;
    public void ResetProgress() => IsCompleted = false;
}