using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastAcademy.Domain.Abstractions;

public interface IBaseEntity
{
    Guid Id { get; set; }
    
    long AutoId { get; set; }
}

public abstract class BaseEntity : IBaseEntity
{
    [Key]
    public Guid Id { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long AutoId { get; set; }
}