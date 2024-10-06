namespace FastAcademy.Domain.Abstractions;

public interface ISoftDeleteEntity
{
    DateTimeOffset DeletedAt { get; set; }
    
    Guid DeletedById { get; set; }
}