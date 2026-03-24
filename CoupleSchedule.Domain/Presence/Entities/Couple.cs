namespace CoupleSchedule.Domain.Presence.Entities;

public sealed class Couple
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid PartnerOneId { get; private set; }
    public Guid PartnerTwoId { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    
    private Couple() { }
    
    public Couple(Guid partnerOneId, Guid partnerTwoId)
    {
        if (partnerOneId == partnerTwoId)
            throw new ArgumentException("Partners cannot be the same");
        
        PartnerOneId = partnerOneId;
        PartnerTwoId = partnerTwoId;
    }
    
    public Guid GetOtherPartnerId(Guid myId) =>
        myId == PartnerOneId ? PartnerTwoId : PartnerOneId;
}