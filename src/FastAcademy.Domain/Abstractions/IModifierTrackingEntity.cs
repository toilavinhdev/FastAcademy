namespace FastAcademy.Domain.Abstractions;

public interface IModifierTrackingEntity : IBaseEntity
{
    Guid CreatedByUserId { get; set; }
    
    Guid? ModifiedByUserId { get; set; }

    void MarkCreate(Guid userId);
    
    void MarkModify(Guid userId);
}

public abstract class ModifierTrackingEntity : BaseEntity, IModifierTrackingEntity
{
    public DateTimeOffset CreatedAt { get; set; }
    
    public Guid CreatedByUserId { get; set; }
    
    public DateTimeOffset? ModifiedAt { get; set; }
    
    public Guid? ModifiedByUserId { get; set; }
    
    public void MarkCreate(Guid userId)
    {
        CreatedAt = DateTimeOffset.UtcNow;
        CreatedByUserId = userId;
    }

    public void MarkModify(Guid userId)
    {
        ModifiedAt = DateTimeOffset.UtcNow;
        ModifiedByUserId = userId;
    }
}