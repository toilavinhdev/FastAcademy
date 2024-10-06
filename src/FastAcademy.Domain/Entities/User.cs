using FastAcademy.Domain.Abstractions;
using FastAcademy.Domain.Enumerations;

namespace FastAcademy.Domain.Entities;

public class User : TimeTrackingEntity
{
    public UserStatus Status { get; set; }
}