namespace FastAcademy.Application.Abstractions.Services;

public interface IFastAcademyDbContext
{
    int SaveChanges();
    
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}