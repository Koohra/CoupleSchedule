using CoupleSchedule.Domain.Presence.Enums;

namespace CoupleSchedule.Domain.Presence.Entities;

public sealed class Partner
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public FocusLevel CurrentFocus { get; set; }
    public string CurrentActivity { get; set; }
    public DateTime LastSeen { get; set; }
    
    private Partner() { }

    public Partner(Guid userId, string name)
    {
        Id = userId;
        Name = name;
        CurrentFocus = FocusLevel.None;
        CurrentActivity = "Iniciando o dia";
        LastSeen = DateTime.UtcNow;
    }

    public void StartFocusSession(string activity, FocusLevel focus)
    {
        CurrentActivity = activity;
        CurrentFocus = focus;
        LastSeen = DateTime.UtcNow;
    }

    public void UpdateStatus(string activity, FocusLevel focus)
    {
        CurrentActivity = activity;
        CurrentFocus = focus;
        LastSeen = DateTime.UtcNow;
    }
}