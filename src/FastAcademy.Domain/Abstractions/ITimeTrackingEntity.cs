namespace FastAcademy.Domain.Abstractions;

public interface ITimeTrackingEntity : IBaseEntity
{
    DateTimeOffset CreatedAt { get; set; }
    
    DateTimeOffset? ModifiedAt { get; set; }

    void MarkCreate();
    
    void MarkModify();
}

public abstract class TimeTrackingEntity : BaseEntity, ITimeTrackingEntity
{
    public DateTimeOffset CreatedAt { get; set; }
    
    public DateTimeOffset? ModifiedAt { get; set; }
    
    public void MarkCreate()
    {
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public void MarkModify()
    {        
        ModifiedAt = DateTimeOffset.UtcNow;
    }
}