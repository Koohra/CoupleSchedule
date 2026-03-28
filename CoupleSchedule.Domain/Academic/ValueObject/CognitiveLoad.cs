namespace CoupleSchedule.Domain.Academic.ValueObject;

public sealed record CognitiveLoad
{
    public int Value { get; }
    public string Description { get; }

    public CognitiveLoad(int value, string description)
    {
        if (value is < 1 or > 5)
            throw new ArgumentOutOfRangeException(nameof(value), "O valor deve estar entre 1 e 5");

        Value = value;
        Description = description;
    }
}