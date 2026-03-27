using CoupleSchedule.Domain.Academic.ValueObject;

namespace CoupleSchedule.Domain.Academic.Entities;

public sealed class Subject
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    private readonly List<Topic> _topics = [];
    public IReadOnlyCollection<Topic> Topics => _topics.AsReadOnly();
    
    private Subject() { }
    
    public Subject(string name)
    {
        Name = name;
    }
    
    public void AddTopic(string title, CognitiveLoad load) => _topics.Add(new Topic(title, load));

    public double GetCompletionPercentage()
    {
        if (_topics.Count == 0) 
            return 0;
        
        var completedTopics = _topics.Count(t => t.IsCompleted);
        return (double)completedTopics / _topics.Count * 100;
    }
}